using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Xpositivo : MonoBehaviour, IVirtualButtonEventHandler {

    bool presionado = false;

    public GameObject botonEjeXPositivo;
    public GameObject objeto;
    public float velocidad = 4;

	// Use this for initialization

	void Start () {


        botonEjeXPositivo = GameObject.Find("BtnMoverXPositivo");//Obtiene el botón
        botonEjeXPositivo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado

	}
	
    public void OnButtonPressed(VirtualButtonBehaviour vb){

        objeto = GameObject.Find("objeto");//Obtiene la figura que va a ser movida
        Debug.Log("Botón presionado");
        presionado = true;




    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){

        Debug.Log("Botón soltado");
        presionado = false;


    }
	// Update is called once per frame
	void Update () {

        //Mueve el botón

        if(presionado){

            objeto.transform.Translate(Vector3.right * Time.deltaTime * velocidad);

        }


	}
}
