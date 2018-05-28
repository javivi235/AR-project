using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MoverObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject boton;

    private bool presionado;

    private GameObject objeto;

    private float velocidad;

	// Use this for initialization
	void Start () {
        boton = GameObject.Find("BtnMovimientoObjeto");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionado = false;
        velocidad = 0.01f;
	}

	// Update is called once per frame
	void Update () {
        if(presionado) {
            Vector3 posicion = objeto.transform.position;
            posicion.x += velocidad;
            objeto.transform.position = posicion;
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
