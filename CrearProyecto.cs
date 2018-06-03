using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrearProyecto : MonoBehaviour {

	public void Crear(InputField a){
		if(a.text != "") {
			
			GameObject Name = GameObject.Find("Name");
			Nombre nombre = Name.GetComponent<Nombre>();
			Nombre.proyecto = a.text;
			Debug.Log( Nombre.proyecto);
			SceneManager.LoadScene("ARNewscene");	
		
		}
	}
}
