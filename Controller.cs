using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject modeloCubo;

    private GameObject cubo;

    private bool instanciado;

	void Start () {
        instanciado = false;
	}
	
	void Update () {
        if (instanciado && Input.GetButton("BtnA")) {
            float x = Input.GetAxis("Horizontal") * 0.01f;
            cubo.transform.Translate(new Vector3(x, 0, 0));
        }
        if(instanciado && Input.GetButton("BtnB")) {
            float x = Input.GetAxis("Horizontal") * 5f;
            cubo.transform.Rotate(new Vector3(x, 0f, 0f));
        }
        if(instanciado && Input.GetButton("BtnX")) {
            float x = Input.GetAxis("Horizontal") * 0.3f;
            cubo.transform.localScale += new Vector3(x, 0f, 0f);
        }
        if (!instanciado && Input.GetButtonDown("BtnY"))
        {
            Instantiate(modeloCubo);
            this.cubo = GameObject.Find("Cube(Clone)");
            instanciado = true;
        }
    }

}
