using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionNegativoX : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarNegativoX;
    public GameObject figura;

    public bool presionando;

    // Use this for initialization
    void Start () {
        vbRotarNegativoX = GameObject.Find("btnRotarNegativoX");
        figura = GameObject.Find("figura");
        vbRotarNegativoX.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        presionando = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        presionando = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        presionando = false;
    }

    // Update is called once per frame
    void Update () {
        if (presionando)
        {
            figura.transform.Rotate(new Vector3(-1f, 0f, 0f));
        }
    }
}
