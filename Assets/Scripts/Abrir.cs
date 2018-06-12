using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Abrir : MonoBehaviour {

	GameObject abrir;
	GameObject borrar;
	// Use this for initialization
	void Start () {
	
	abrir  = GameObject.Find("botonAbrir");
	borrar  = GameObject.Find("botonBorrar");
	abrir.SetActive(false);
	borrar.SetActive(false);
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        var index = 0;

        foreach(FileInfo file in dir.GetFiles())
        {

            if (file.Extension == ".txt")
            {

                index = index + 1;

		
                Vector3 v = new Vector3(0, index * 50, 0);
                var button = Instantiate(Resources.Load<GameObject>("botonProyecto"), v, Quaternion.identity);

                button.GetComponentInChildren<Text>().text = Path.GetFileNameWithoutExtension(file.Name);
		button.name = Path.GetFileNameWithoutExtension(file.Name);
		
                button.transform.SetParent(GameObject.Find("Lista").transform, false);
                button.GetComponent<Button>().onClick.AddListener(delegate { select(Path.GetFileNameWithoutExtension(file.Name)); });

            }

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    	void open() {
	GameObject Name = GameObject.Find("Name");
        Nombre nombre = Name.GetComponent<Nombre>();
	if(Nombre.proyecto != ""){

	SceneManager.LoadScene("EscenaConstruccion");


	}
        
    }
   
    void delete(){
	
	GameObject Name = GameObject.Find("Name");
        Nombre nombre = Name.GetComponent<Nombre>();	
	File.Delete(Application.persistentDataPath + "/" + Nombre.proyecto + ".txt");
	Destroy(GameObject.Find(Nombre.proyecto));
        //Nombre.proyecto = "";

        abrir.SetActive(false);
	borrar.SetActive(false);
	
	
	}

    void select (string name) {
	
	GameObject Name = GameObject.Find("Name");
        Nombre nombre = Name.GetComponent<Nombre>();
        Nombre.proyecto = name;
        abrir.GetComponent<Button>().onClick.AddListener(delegate {open();});
	borrar.GetComponent<Button>().onClick.AddListener(delegate { delete(); });
	abrir.SetActive(true);
	borrar.SetActive(true);

	}
}