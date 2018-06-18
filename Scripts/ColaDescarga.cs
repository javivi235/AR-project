using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using System.Threading.Tasks;
using System;
using System.IO;
using Firebase.Database;
using Firebase.Auth;
using System.Text;
using System.Text.RegularExpressions;
using Firebase.Unity.Editor;

public class ColaDescarga : MonoBehaviour {

    Firebase.Auth.FirebaseUser newUser;

    // Use this for initialization
    void Start () {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync("javisoruco235@gmail.com", "pass123").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            this.newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://buildit-fc375.firebaseio.com/");
            DatabaseReference dbreference = FirebaseDatabase.DefaultInstance.RootReference;
            FirebaseDatabase.DefaultInstance
            .GetReference("ColaDescarga/" + newUser.UserId)
            .GetValueAsync().ContinueWith(task1 => {
                if (task1.IsFaulted)
                {
                // Handle the error...
                Debug.Log("Sin coincidencias");
                }
                else if (task1.IsCompleted)
                {
                    Debug.Log("Datos encontrados");
                    DataSnapshot snapshot = task1.Result;

                    // Do something with snapshot...

                    int index = 0;

                foreach (DataSnapshot snap in snapshot.Children)
                    {
                    //  IDictionary dictUser = (IDictionary)user.Value;
                    //  Debug.Log("" + dictUser["email"] + " - " + dictUser["password"]);
                    Debug.Log("Encontrado: "+ snap.Value);
                        Regex filtro = new Regex(@"\|\|\|");
                        string[] data = filtro.Split(snap.Value.ToString());
                        index = index + 1;
                        Vector3 v = new Vector3(0, index * -50, 0);
                        var button = Instantiate(Resources.Load<GameObject>("Boton"), v, Quaternion.identity);

                        button.GetComponentInChildren<Text>().text = data[0] + " : " + data[2];

                        button.name = data[0];

                        button.transform.SetParent(GameObject.Find("Image").transform, false);
                        button.GetComponent<Button>().onClick.AddListener(delegate { descargar(data[0], data[1]); });
                    }
                }
            });
        });
       

    }

    void descargar(string nombre, string extencion) {

        Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
        Firebase.Storage.StorageReference reference =
       storage.GetReference(nombre + "." + extencion);
        // Download to the local filesystem
        // Create local filesystem URL
        reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Download URL: " + task.Result);
                // ... now download the file via WWW or UnityWebRequest.
                WWW www = new WWW(task.Result.ToString());
                while (!www.isDone)
                {
                    //  progress = "downloaded " + (www.progress * 100).ToString() + "%...";
                    //yield return null;
                }

                string fullPath = Application.persistentDataPath + "/" + nombre + "." + extencion;
                System.IO.File.WriteAllBytes(fullPath, www.bytes);

            }
        });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
