using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotacionPositivoZ : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbRotarPositivoZ;
    public GameObject figura;

    public bool presionando;

    // Use this for initialization
    void Start () {
        vbRotarPositivoZ = GameObject.Find("btnRotarPositivoZ");
        figura = GameObject.Find("figura");
        vbRotarPositivoZ.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
            figura.transform.Rotate(new Vector3(0f, 0f, 1f));
        } 
	}
}
