using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccionar : MonoBehaviour {

    // Use this for initialization
    public GameObject[] objetos;
    public GameObject ejes;
    public Shader contorno;
    public Shader noContorno;
    public int numero;
    public Renderer rend;
    public Renderer rend2;
    

    void Start () {
        ejes = GameObject.FindGameObjectWithTag("eje");
        contorno = Shader.Find("Unlit/Contorno2");
        noContorno = Shader.Find("Standard");
        objetos = GameObject.FindGameObjectsWithTag("Obj");
        numero = 0;
        foreach(GameObject obj in objetos)
        {
            Debug.Log(obj.name);
        }
        Debug.Log(numero);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("left"))
        {
            if (numero == 0)
            {
                numero = objetos.Length - 1;
                rend = objetos[numero].GetComponent<Renderer>();
                rend2 = objetos[0].GetComponent<Renderer>();
                rend.material.shader = contorno;
                rend2.material.shader = noContorno;

            }

            else
            {
                numero -= 1;
                objetos[numero].AddComponent<LineRenderer>();
                rend = objetos[numero].GetComponent<Renderer>();
                rend2 = objetos[numero + 1].GetComponent<Renderer>();
                rend.material.shader = contorno;
                rend2.material.shader = noContorno;
            }
            Debug.Log(rend.material.shader.name);
            ejes.transform.SetParent(objetos[numero].transform, false);
            ejes.transform.Translate(Vector3.zero);
            ejes.transform.Rotate(Vector3.zero);
        }
        else if (Input.GetKeyDown("right"))
        {
            if (numero == objetos.Length - 1)
            {
                numero = 0;
                rend = objetos[numero].GetComponent<Renderer>();
                rend2 = objetos[objetos.Length - 1].GetComponent<Renderer>();
                rend.material.shader = contorno;
                rend2.material.shader = noContorno;

            }
            else
            {
                numero += 1;
                rend = objetos[numero].GetComponent<Renderer>();
                rend2 = objetos[numero - 1].GetComponent<Renderer>();
                rend.material.shader = contorno;
                rend2.material.shader = noContorno;

            }
           
            Debug.Log(numero);
        }
		
	}
}
