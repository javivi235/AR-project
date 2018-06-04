using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionNegativoZ : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarNegativoZ;
    public GameObject figura;

    public bool presionando;
    
    void Start () {
        vbRotarNegativoZ = GameObject.Find("BtnRotacionNegativoZ");
        figura = GameObject.Find("Pared(Clone)");
        vbRotarNegativoZ.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionando = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        presionando = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        presionando = false;
    }

    void Update() {
        if (presionando)
        {
            figura.transform.Rotate(new Vector3(0f, 0f, -1f));
        }
    }
}
