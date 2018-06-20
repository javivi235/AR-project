using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using System.Threading.Tasks;
using System;
using System.IO;
using Firebase.Database;
using System.Text;
using System.Text.RegularExpressions;
using Firebase.Unity.Editor;

public class ColaDescarga : MonoBehaviour
{

	public static List<String> nombres;
	public static List<String> extencion;
	public static List<String> codigo;

	public static List<GameObject> descargables;
	
	// Use this for initialization
	void Start()
	{

		nombres = new List<string>();
		codigo = new List<string>();
		extencion = new List<string>();


		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://buildit-fc375.firebaseio.com/");
		DatabaseReference dbreference = FirebaseDatabase.DefaultInstance.RootReference;

		FirebaseDatabase.DefaultInstance
		.GetReference("ColaDescarga/" + Nombre.userId)
		.GetValueAsync().ContinueWith(listaDescargas =>
		{

			if (listaDescargas.IsFaulted)
			{

			}
			else if (listaDescargas.IsCompleted)
			{

				Debug.Log("Datos encontrados");
				DataSnapshot snapshot = listaDescargas.Result;
				int indice = 0;

				foreach (DataSnapshot snap in snapshot.Children)
				{

					Debug.Log("Encontrado: " + snap.Value);
					Regex filtro = new Regex(@"\|\|\|");
					string[] datos = filtro.Split(snap.Value.ToString());
					nombres.Add(datos[0]);
					extencion.Add(datos[1]);
					codigo.Add(datos[2]);
					obtenerArchivo(datos[0], datos[1], datos[2]);
				}

			}

		});

	}

	void obtenerArchivo(string nombre, string extencion, string codigo)
	{

		Debug.Log("ARCHIVO BUSCADO: " + nombre + "&&" + codigo + "." + extencion);
		Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
		Firebase.Storage.StorageReference reference =
		storage.GetReference(nombre + "&&" + codigo + "." + extencion);

		reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> linkDescarga) =>
		{

			if (!linkDescarga.IsFaulted && !linkDescarga.IsCanceled)
			{

				StartCoroutine(descargar(linkDescarga.Result.ToString(), nombre, extencion, codigo));

			}

		});

	}

	IEnumerator descargar(string link, string nombre, string extencion, string codigo)
	{

		//WWW www =  WWW.LoadFromCacheOrDownload("file:///" + Application.dataPath + "/AssetBundles/model.wolf", 1);
		WWW www = WWW.LoadFromCacheOrDownload(link, 1);

		while (!www.isDone)
		{
			Debug.Log(www.progress);
			yield return null;
		}

		yield return www;
		AssetBundle assetBundle = www.assetBundle;
		descargables.Add((GameObject)assetBundle.LoadAsset(nombre + "&&" + codigo));

	}



}