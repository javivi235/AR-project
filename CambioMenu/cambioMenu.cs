using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class cambioMenu : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject botonDerecho;
    public GameObject botonIzquierdo;
    public GameObject planoX;
    public GameObject planoXNeg;
    public GameObject planoY;
    public GameObject planoYNeg;
    public GameObject planoZ;
    public GameObject planoZNeg;
    public GameObject cambioMenu1;
    public GameObject cubo;



	// Use this for initialization
	void Start () {

        botonIzquierdo = GameObject.Find("xPositivo");
        botonDerecho = GameObject.Find("xNegativo");

        planoXNeg = GameObject.Find("PlanoXNeg");
        planoX = GameObject.Find("PlanoX");
        planoYNeg = GameObject.Find("PlanoYNeg");
        planoY = GameObject.Find("PlanoY");
        planoYNeg = GameObject.Find("PlanoZNeg");
        planoY = GameObject.Find("PlanoZ");


        cambioMenu1 = GameObject.Find("cambioMenu");
        cubo = GameObject.Find("Cube");

        cambioMenu1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);




                      

            
	}
    public void OnButtonPressed(VirtualButtonBehaviour vb){

        if(cubo.GetComponent<Xpositivo>().enabled){

            //Deshabilita el botón del eje X
            cubo.GetComponent<Xpositivo>().enabled = false;
            cubo.GetComponent<Xnegativo>().enabled = false;

            //Desactiva la parte gráfica del botón
            planoX.SetActive(false);
            planoXNeg.SetActive(false);
            planoZ.SetActive(false);
            planoZNeg.SetActive(false);


            //Habilita el botón del eje Y
            cubo.GetComponent<Ypositivo>().enabled = true;
            cubo.GetComponent<Ynegativo>().enabled = true;

            // Activa la parte gráfica del botón
            planoY.SetActive(true);
            planoYNeg.SetActive(true);


           
        }else if(cubo.GetComponent<Ypositivo>().enabled){

            //Deshabilita el botón del eje Y

            cubo.GetComponent<Ypositivo>().enabled = false;
            cubo.GetComponent<Ynegativo>().enabled = false;

            //Desactiva la parte gráfica del botón

            planoY.SetActive(false);
            planoYNeg.SetActive(false);


            //Habilita el botón del eje Z

            cubo.GetComponent<Zpositivo>().enabled = true;
            cubo.GetComponent<Znegativo>().enabled = true;

            // Activa la parte gráfica del botón

            planoZ.SetActive(true);
            planoZNeg.SetActive(true);


        }else if(cubo.GetComponent<Zpositivo>().enabled){

            //Deshabilita el botón del eje Z

            cubo.GetComponent<Zpositivo>().enabled = false;
            cubo.GetComponent<Znegativo>().enabled = false;

            //Desactiva la parte gráfica del botón

            planoZ.SetActive(false);
            planoZNeg.SetActive(false);



            //Habilita el botón del eje X

            cubo.GetComponent<Xpositivo>().enabled = true;
            cubo.GetComponent<Xnegativo>().enabled = true;


            // Activa la parte gráfica del botón

            planoX.SetActive(true);
            planoXNeg.SetActive(true);

        }


    }
    public void OnButtonReleased(VirtualButtonBehaviour vb){
        
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
