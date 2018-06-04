using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Ynegativo : MonoBehaviour, IVirtualButtonEventHandler
{

    bool presionado = false;

    public GameObject botonEjeYNegativo;
    public float velocidad = 1;
    public GameObject objeto;


    // Use this for initialization
    void Start()
    {

        botonEjeYNegativo = GameObject.Find("xNegativo");//Obtiene el botón
        botonEjeYNegativo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        objeto = GameObject.Find("objeto");
        Debug.Log("Botón presionado");
        presionado = true;




    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Botón soltado");
        presionado = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (presionado)
        {

            objeto.transform.Translate(Vector3.back * Time.deltaTime * velocidad);

        }
    }
}
