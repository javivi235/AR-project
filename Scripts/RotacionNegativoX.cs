using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionNegativoX : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarNegativoX;
    public GameObject figura;

    public bool presionando;

    void Start () {
        vbRotarNegativoX = GameObject.Find("BtnRotacionNegativoX");
        figura = GameObject.Find("Pared(Clone)");
        vbRotarNegativoX.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionando = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        presionando = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        presionando = false;
    }
    
    void Update () {
        if (presionando)
        {
            figura.transform.Rotate(new Vector3(-1f, 0f, 0f));
        }
    }
}
