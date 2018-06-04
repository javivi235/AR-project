using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Xnegativo : MonoBehaviour, IVirtualButtonEventHandler {

    bool presionado = false;

    public GameObject botonEjeXNegativo;
    public float velocidad = 4;
    public GameObject objeto;



	// Use this for initialization
	void Start () {
		
        botonEjeXNegativo = GameObject.Find("BtnMoverXNegativo");//Obtiene el botón
        botonEjeXNegativo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        
        objeto = GameObject.Find("objeto");//Obtiene la figura que va a ser movido
        Debug.Log("Botón presionado");
        presionado = true;




    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Botón soltado");
        presionado = false;


    }
	
	// Update is called once per frame
	void Update () {
		
        if (presionado)
        {

            objeto.transform.Translate(Vector3.left * Time.deltaTime * velocidad);

        }
	}
}
