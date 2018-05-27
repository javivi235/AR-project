using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AgregarObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject boton;
    public GameObject modelo;

    public Transform target;
    
    private bool botonPresionado;
    private bool crear;

    private GameObject objeto;

    void Start() {
        boton = GameObject.Find("BotonAgregar");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        botonPresionado = false;
        crear = true;
    }
    
    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        if(!botonPresionado && crear) {
            objeto = Instantiate(modelo, target.position, target.rotation);
            botonPresionado = true;
        } else {
            Destroy(objeto);
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        crear = !crear;
        botonPresionado = false;
    }

}