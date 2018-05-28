using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScriptAgregarObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject boton;
    public GameObject modelo;

    public Transform target;

    private bool botonPresionado;
    private bool crear;

    private GameObject objeto;

    void Start() {
        boton = GameObject.Find("BtnAgregarObjeto");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        botonPresionado = false;
        crear = true;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        Vector3 posicion = target.position;
        posicion.y += 0.5f; 

        if(!botonPresionado && crear) {
            objeto = Instantiate(modelo, posicion, target.rotation);
            botonPresionado = true;
        } else {
            // Destroy(objeto);
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        crear = !crear;
        botonPresionado = false;
    }

}
