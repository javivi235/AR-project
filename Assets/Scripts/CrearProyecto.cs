using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class CrearProyecto : MonoBehaviour {

	public void Crear(InputField a){
		if(a.text != "") {

		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
		bool existencia = false;
	        foreach(FileInfo file in dir.GetFiles())
        	{
			if(Path.GetFileNameWithoutExtension(file.Name) == a.text){
				
				existencia = true;			
	
			}
		}
		if(!existencia){

		
			//GameObject Name = GameObject.Find("Name");
			//Nombre nombre = Name.GetComponent<Nombre>();
			//Nombre.proyecto = a.text;
			Debug.Log( Nombre.proyecto);
			SceneManager.LoadScene("EscenaConstruccion");	

		}else {

		}	
		
		}
	}
}
