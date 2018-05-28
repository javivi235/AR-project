using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotarObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject boton;

    private bool presionado;

    private float velocidad;

    private GameObject objeto;

    // Use this for initialization
    void Start () {       
        boton = GameObject.Find("BtnRotacionObjeto");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionado = false;
        velocidad = 10f; 
    }
	
	// Update is called once per frame
	void Update () {
        if(presionado) {
            objeto.transform.Rotate(new Vector3(0, velocidad, 0));
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        presionado = true;
        objeto = GameObject.Find("Pared(Clone)");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        presionado = false;
        velocidad = -velocidad;
    }

}