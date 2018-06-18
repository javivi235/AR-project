using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyudaControl : MonoBehaviour {

    public GameObject ayuda;

    private bool ayudaActivada;

    // Use this for initialization
    void Start () {
        ayudaActivada = false;
    }
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetButtonDown("BtnTriangulo"))
        if (Input.GetButtonDown("BtnR2"))
        {
            if (ayudaActivada)
            {
                ayuda.SetActive(false);
                ayudaActivada = false;
                menuPrincipal.SetActive(false);
                menuAgregar.SetActive(false);
            }
            else
            {
                ayuda.SetActive(true);
                ayudaActivada = true;
                menuPrincipal.SetActive(false);
                menuAgregar.SetActive(false);
            }
        }
       
    }
}
