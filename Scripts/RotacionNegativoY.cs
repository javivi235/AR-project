using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionNegativoY : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarNegativoY;
    public GameObject figura;

    public bool presionando;

    void Start () {
        vbRotarNegativoY = GameObject.Find("BtnRotacionNegativoY");
        figura = GameObject.Find("Pared(Clone)");
        vbRotarNegativoY.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
            figura.transform.Rotate(new Vector3(0f, -1f, 0f));
        }
    }
}
