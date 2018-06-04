using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BtnVolverMenuMov : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject botonMoverXPositivo;
    public GameObject botonMoverXNegativo;
    public GameObject botonVolver;





	// Use this for initialization
	void Start () {

        botonMoverXPositivo = GameObject.Find("BtnMoverXPositivo");
        botonMoverXNegativo = GameObject.Find("BtnMoverXNegativo");
        botonVolver.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado

	}

    public void OnButtonPressed(VirtualButtonBehaviour vb){

       // Destroy(botonMoverXPositivo);
        //Destroy(botonMoverXNegativo);


    }

    public  void OnButtonReleased(VirtualButtonBehaviour vb){


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
