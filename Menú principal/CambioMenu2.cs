using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CambioMenu2 : MonoBehaviour, IVirtualButtonEventHandler
{

    private GameObject boton;
    private GameObject menu1;
    private GameObject menu2;
    private GameObject menu3;

    // Use this for initialization
    void Start()
    {
        boton = GameObject.Find("RotarBtn");
        menu1 = GameObject.Find("Menu1");
        menu2 = GameObject.Find("Menu2");
        menu3 = GameObject.Find("Menu3");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
 
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
        menu3.SetActive(false);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}