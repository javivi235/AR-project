using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nombre : MonoBehaviour {

	public static Nombre nombre;
	public static string proyecto;
	public static string userId;

	void Awake(){
	
	if(nombre == null){
		
		nombre = this;	
		DontDestroyOnLoad (transform.gameObject);	
	
	} else if (nombre = this){
		Destroy(transform.gameObject);
	}
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
