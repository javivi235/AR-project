using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EscalarObjeto : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject boton;

    private bool presionado;

    private float velocidad;

    private GameObject objeto;

    // Use this for initialization
    void Start () {
        boton = GameObject.Find("BtnEscalaObjeto");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionado = false;
        velocidad = 0.008f;
    }
	
	// Update is called once per frame
	void Update () {
        if(presionado) {
            objeto.transform.localScale += new Vector3(velocidad, velocidad, velocidad);
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
