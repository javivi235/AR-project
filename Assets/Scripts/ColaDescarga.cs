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

	public GameObject aviso;
	public GameObject cargado;
	public GameObject descargas;

	public Slider barra_carga;

	// Use this for initialization
	void Start()
	{

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
					indice = indice + 1;
					Vector3 v = new Vector3(0, indice * -50, 0);
					var botonDescarga = Instantiate(Resources.Load<GameObject>("botonProyecto"), v, Quaternion.identity);
					botonDescarga.GetComponentInChildren<Text>().text = datos[0] + " : " + datos[2];
					botonDescarga.name = datos[0];
					botonDescarga.transform.SetParent(GameObject.Find("Lista").transform, false);
					botonDescarga.GetComponent<Button>().onClick.AddListener(delegate { obtenerArchivo(datos[0], datos[1], datos[2]);});

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

			cargado.SetActive(true);
			descargas.SetActive(false);
			StartCoroutine(descargar(linkDescarga.Result.ToString(), nombre, extencion, codigo));

		}

	});

}

IEnumerator descargar(string link, string nombre, string extencion, string codigo)
{

	Debug.Log("descargando.. " + link);
	WWW descarga = new WWW(link);

	while (!descarga.isDone)
	{

		barra_carga.value = Mathf.Clamp01(descarga.progress);
		yield return null;

	}

	cargado.gameObject.SetActive(false);
	descargas.SetActive(true);
	barra_carga.value = 0;
	aviso.SetActive(true);
	aviso.GetComponentInChildren<Text>().text = nombre + " Descargado Exitosamente!";
	string fullPath = Application.dataPath + @"\Resources\" + nombre + "&&" + codigo + "." + extencion;
	//Para correr en PC comente la anterior linea y use la siguiente
	//string fullPath = "Assets/Resources/" + nombre + "&&" + codigo + "." + extencion;
	System.IO.File.WriteAllBytes(fullPath, descarga.bytes);
	yield return new WaitForSeconds(3);
	aviso.SetActive(false);

}

void Update()
{

}

}