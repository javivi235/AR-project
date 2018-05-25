using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Znegativo : MonoBehaviour, IVirtualButtonEventHandler
{

    bool presionado = false;

    public GameObject botonEjeZNegativo;
    public float velocidad = 1;


    // Use this for initialization
    void Start()
    {

        botonEjeZNegativo = GameObject.Find("xNegativo");//Obtiene el botón
        botonEjeZNegativo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);//Registra el cambio que ocurrirá cuando el botón sea presionado o soltado
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

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

            transform.Translate(Vector3.down * Time.deltaTime * velocidad);

        }
    }
}
