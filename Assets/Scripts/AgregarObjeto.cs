using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AgregarObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject boton;
    public GameObject modelo;

    private GameObject target;

    private bool botonPresionado;
    private bool crear;

    private GameObject objeto;

    void Start() {
        boton = GameObject.Find("BtnAgregarObjeto");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        target = GameObject.Find("Ground Plane Stage");
        botonPresionado = false;
        crear = true;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        Vector3 posicion = target.transform.position;
        posicion.y += 0.5f; 

        if(!botonPresionado && crear) {
            objeto = Instantiate(modelo, posicion, target.transform.rotation);
            objeto.transform.parent = target.transform;
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
