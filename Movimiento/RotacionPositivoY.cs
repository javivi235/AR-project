using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionPositivoY : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarPositivoY;
    public GameObject figura;

    public bool presionando;

    // Use this for initialization
    void Start () {
        vbRotarPositivoY = GameObject.Find("btnRotarPositivoY");
        figura = GameObject.Find("figura");
        vbRotarPositivoY.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
            figura.transform.Rotate(new Vector3(0f, 1f, 0f));
        }
    }
}
