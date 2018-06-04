using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VolverMenuMov1 : MonoBehaviour, IVirtualButtonEventHandler {



    public GameObject botonPos;
    public GameObject botonNeg;
    public GameObject botonVolver;
	// Use this for initialization
	

    void Start () {
		
        botonPos = GameObject.Find("BtnMoverZPositivo");
        botonNeg = GameObject.Find("BtnMoverZNegativo");
        botonVolver = GameObject.Find("BtnVolverMenuMover2");
        botonVolver.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado
	
    }
	
    public void OnButtonPressed(VirtualButtonBehaviour vb){
        
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb){
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
