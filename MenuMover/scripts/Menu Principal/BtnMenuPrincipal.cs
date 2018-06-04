using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BtnMenuPrincipal : MonoBehaviour,IVirtualButtonEventHandler {


    public GameObject botonMoverX;
    public GameObject botonMoverY;
    public GameObject botonMoverZ;
    public GameObject botonVolver;


	// Use this for initialization
	void Start () {

        botonMoverX = GameObject.Find("BtnMoverX");
        botonMoverY = GameObject.Find("BtnMoverY");
        botonMoverZ = GameObject.Find("BtnMoverZ");
        botonVolver = GameObject.Find("BtnVolverAtras");
        botonVolver.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado


	}

    public void OnButtonPressed(VirtualButtonBehaviour vb){

        //Espero que el código que pongo te ayude a completar, sino bórralo sin problema

        Destroy(botonMoverX);
        Destroy(botonMoverY);
        Destroy(botonMoverZ);


    }


    public void OnButtonReleased(VirtualButtonBehaviour vb){
        
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
