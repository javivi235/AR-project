using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionPositivoX : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarPositivoX;
    public GameObject figura;

    public bool presionando;

    // Use this for initialization
    void Start () {
        vbRotarPositivoX = GameObject.Find("btnRotarPositivoX");
        figura = GameObject.Find("figura");
        vbRotarPositivoX.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
            figura.transform.Rotate(new Vector3(1f, 0f, 0f));
        }
    }
}
