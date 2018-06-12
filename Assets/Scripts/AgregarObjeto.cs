using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgregarObjeto : MonoBehaviour {

    public GameObject modeloPared;
    public GameObject modeloPuerta;
    public GameObject modeloVentana;

    private GameObject target;
    private GameObject objeto;

    public GameObject[] objetos;
    public Shader contorno;
    public Shader noContorno;
    public int numero;
    public Renderer rend;
    public Renderer rend2;

    public GameObject menuPrincipal;
    public GameObject menuAgregar;

    private bool menuActivado;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("ImageTarget");
	    contorno = Shader.Find("Unlit/Contorno2");
        noContorno = Shader.Find("Standard");
        objetos = GameObject.FindGameObjectsWithTag("Obj");
        numero = -1;
        menuActivado = false;

        foreach (GameObject obj in objetos)
        {
            Debug.Log(obj.name);
        }
        Debug.Log(numero);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("BtnL2"))
        {
            if (menuActivado)
            {
                menuPrincipal.SetActive(false);
                menuAgregar.SetActive(false);
                menuActivado = false;
            } else
            {
                menuPrincipal.SetActive(true);
                menuAgregar.SetActive(false);
                menuActivado = true;
            }
        }

        if (!menuActivado)
        {
            Seleccionar();
            if (numero != -1)
            {
                if (Input.GetButton("BtnX"))
                {
                    float x = Input.GetAxis("Horizontal") * 0.01f;
                    float y = Input.GetAxis("Vertical") * 0.01f;
                    objetos[numero].transform.Translate(new Vector3(x, y, 0));
                }
                if (Input.GetButton("BtnCirculo"))
                {
                    float x = Input.GetAxis("Horizontal") * 5f;
                    objetos[numero].transform.Rotate(new Vector3(x, 0f, 0f));
                }
                if (Input.GetButton("BtnCuadrado"))
                {
                    float x = Input.GetAxis("Horizontal") * 0.3f;
                    objetos[numero].transform.localScale += new Vector3(x, 0f, 0f);
                }
            }
        }
    }

    public void CrearPared()
    {
        Vector3 posicion = target.transform.position;
        posicion.y += 0.5f;

        objeto = Instantiate(modeloPared, posicion, target.transform.rotation);
        objeto.transform.parent = target.transform;
	    objeto.tag = "Obj";
	    objetos = GameObject.FindGameObjectsWithTag("Obj");
        numero = objetos.Length - 1;
        if (numero != 0)
        {
            rend = objetos[numero].GetComponent<Renderer>();
            rend2 = objetos[numero - 1].GetComponent<Renderer>();
            rend.material.shader = contorno;
            rend2.material.shader = noContorno;
        }

    }

    public void CrearPuerta()
    {
        Vector3 posicion = target.transform.position;
        posicion.y += 0.5f;

        objeto = Instantiate(modeloPuerta, posicion, target.transform.rotation);
        objeto.transform.parent = target.transform;
  	    objeto.tag = "Obj";
	    objetos = GameObject.FindGameObjectsWithTag("Obj");
	    numero = objetos.Length - 1;
        if (numero != 0)
        {
            rend = objetos[numero].GetComponent<Renderer>();
            rend2 = objetos[numero - 1].GetComponent<Renderer>();
            rend.material.shader = contorno;
            rend2.material.shader = noContorno;
        }
    }
    
    public void CrearVentana()
    {
        Vector3 posicion = target.transform.position;
        posicion.y += 0.5f;

        objeto = Instantiate(modeloVentana, posicion, target.transform.rotation);
        objeto.transform.parent = target.transform;
	    objeto.tag = "Obj";
	    objetos = GameObject.FindGameObjectsWithTag("Obj");
	    numero = objetos.Length - 1;
        if (numero != 0)
        {
            rend = objetos[numero].GetComponent<Renderer>();
            rend2 = objetos[numero - 1].GetComponent<Renderer>();
            rend.material.shader = contorno;
            rend2.material.shader = noContorno;
        }
    }
    public void Seleccionar()
    {
        if (objetos.Length == 1)
        {
            rend = objetos[numero].GetComponent<Renderer>();
            rend.material.shader = contorno;
        }
        else
        {
            if (Input.GetButtonDown("BtnL1"))
            {
                if (numero == 0)
                {
                    numero = objetos.Length - 1;
                    rend = objetos[numero].GetComponent<Renderer>();
                    rend2 = objetos[0].GetComponent<Renderer>();
                    rend.material.shader = contorno;
                    rend2.material.shader = noContorno;
                    Debug.Log(numero);

                }

                else
                {
                    numero -= 1;
                    rend = objetos[numero].GetComponent<Renderer>();
                    rend2 = objetos[numero + 1].GetComponent<Renderer>();
                    rend.material.shader = contorno;
                    rend2.material.shader = noContorno;
                    Debug.Log(numero);
                }
                Debug.Log(rend.material.shader.name);
            }
            else if (Input.GetButtonDown("BtnR1"))
            {
                if (numero == objetos.Length - 1)
                {
                    numero = 0;
                    rend = objetos[numero].GetComponent<Renderer>();
                    rend2 = objetos[objetos.Length - 1].GetComponent<Renderer>();
                    rend.material.shader = contorno;
                    rend2.material.shader = noContorno;
                    Debug.Log(numero);

                }
                else
                {
                    numero += 1;
                    rend = objetos[numero].GetComponent<Renderer>();
                    rend2 = objetos[numero - 1].GetComponent<Renderer>();
                    rend.material.shader = contorno;
                    rend2.material.shader = noContorno;
                    Debug.Log(numero);
                }
            }

        }
    }
}
