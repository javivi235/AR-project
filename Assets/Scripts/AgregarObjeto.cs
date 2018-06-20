﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgregarObjeto : MonoBehaviour
{
    public GameObject modeloPared;
    public GameObject modeloPuerta;
    public GameObject modeloVentana;
	public GameObject ejes;
    private GameObject target;
    private GameObject objeto;

    private GameObject[] objetos;
    public Shader contorno;
    private Shader noContorno;
    private int numero;
    private Renderer rend;
    private Renderer rend2;

    public GameObject menuPrincipal;
    public GameObject menuAgregar;
	public GameObject opcionBorrar;
	public GameObject opcionAyuda;

	public GameObject panelCrear;

	private GameObject scrollbarObject;
	private Scrollbar scrollbar;

    private bool menuActivado;
	private bool opcionBorradoActivado;
	private bool opcionAyudaActivada;
	private bool objetosListados;
	public Color c2 = new Color(1, 1, 1, 0);

	void Start()
    {
		ejes = GameObject.FindGameObjectWithTag("Eje");
		target = GameObject.Find("ImageTarget");
        noContorno = Shader.Find("Standard");
        objetos = GameObject.FindGameObjectsWithTag("Obj");

        numero = -1;

		menuActivado = false;
		opcionBorradoActivado = false;
		opcionAyudaActivada = false;
		objetosListados = false;
    }
	
	void Update()
    {
		if (Input.GetButtonDown("BtnL2") && !opcionAyudaActivada)
        {
			if (menuActivado)
			{
				menuPrincipal.SetActive(false);
				menuAgregar.SetActive(false);
				menuActivado = false;
			}
			else
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
                    float x = Input.GetAxis("IzquierdaHorizontal") * 0.01f;
                    float y = Input.GetAxis("IzquierdaVertical") * 0.01f;
                    float z = Input.GetAxis("DerechaVertical") * 0.01f;
                    objetos[numero].transform.Translate(new Vector3(x, z, y));
                }
                if (Input.GetButton("BtnCirculo"))
                {
                    float x = Input.GetAxis("IzquierdaHorizontal") * 5f;
                    objetos[numero].transform.Rotate(new Vector3(x, 0f, 0f));
                }
                if (Input.GetButton("BtnCuadrado"))
                {
                    float x = Input.GetAxis("IzquierdaHorizontal") * 0.005f;
                    objetos[numero].transform.localScale += new Vector3(x, 0f, 0f);
                }
            }
        }
		else
		{
			if (panelCrear.activeSelf)
			{
				scrollbarObject = GameObject.Find("Scrollbar");
				scrollbar = scrollbarObject.GetComponent<Scrollbar>();
				float m = Input.GetAxis("DerechaHorizontal") * 0.0001f;
				scrollbar.value += m;
				if (!objetosListados)
				{
					ListarObjetos();
					objetosListados = true;
				}
			}
		}

		if (Input.GetButtonDown("BtnR2"))
		{
			if (opcionBorradoActivado) {
				opcionBorrar.SetActive(false);
				opcionBorradoActivado = false;
			}
			else
			{
				opcionBorrar.SetActive(true);
				opcionBorradoActivado = true;
			}
		}

		if(Input.GetButtonDown("BtnTriangulo")){
			opcionAyudaActivada = !opcionAyudaActivada;
			opcionAyuda.SetActive(opcionAyudaActivada);
			menuPrincipal.SetActive(false);
			menuAgregar.SetActive(false);
			opcionBorrar.SetActive(false);
		}
	}

	public void ListarObjetos()
	{
		UnityEngine.Object[] lista = Resources.LoadAll("Objetos", typeof(GameObject));

		GameObject modeloBoton = (GameObject)(Resources.Load("BotonObjeto"));
		GameObject textoPrincipal = GameObject.Find("TextoPanelCrear");
		GameObject modeloTexto = (GameObject)Resources.Load("NombreObjeto");

		GameObject listaBotones = GameObject.Find("ListaObjetos");

		int cantidad = 0;

		foreach (var file in lista)
		{
			string nombre = "";
			for (int i = 0; i < file.name.Length; i++)
			{
				if (file.name[i] != '.')
				{
					nombre += file.name[i];
				}
				else
				{
					break;
				}
			}

			GameObject boton = Instantiate(modeloBoton, listaBotones.transform);
			boton.transform.position += new Vector3(300 * cantidad++, 0, 0);
			boton.transform.SetParent(GameObject.Find("ListaBotones").transform);

			GameObject modelo = boton.transform.Find("Pared").gameObject;
			GameObject newObj = Instantiate((GameObject)file) as GameObject;
			newObj.transform.SetParent(boton.transform);
			modelo.transform.parent = newObj.transform.parent;
			newObj.transform.parent = modelo.transform.parent;
			DestroyImmediate(modelo);

			GameObject texto = boton.transform.Find("Nombre").gameObject;
			Text txt = texto.GetComponent<Text>();
			txt.text = file.name;

			GameObject botonUI = boton.transform.Find("ModeloBoton").gameObject;
			Button componenteBoton = botonUI.GetComponent<Button>();
			componenteBoton.onClick.AddListener(delegate { Instanciar(nombre); });
		}
	}

	public void Instanciar(string nombre)
	{
		GameObject modeloObjeto = (GameObject)(Resources.Load("Objetos/" + nombre));

		Vector3 posicion = target.transform.position;

		objeto = Instantiate(modeloObjeto, posicion, target.transform.rotation);
		objeto.transform.SetParent(target.transform);
		objeto.tag = "Obj";
		objetos = GameObject.FindGameObjectsWithTag("Obj");
		numero = objetos.Length - 1;
		rend = objetos[numero].GetComponent<Renderer>();
		if(numero >= 1)
		{
			rend2 = objetos[numero - 1].GetComponent<Renderer>();
			rend2.material.shader = noContorno;
		}
		rend.material.shader = contorno;
		ejes.transform.SetParent(objetos[numero].transform, false);
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
				ejes.transform.SetParent(objetos[numero].transform, false);


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
				ejes.transform.SetParent(objetos[numero].transform, false);
			}

        }
    }
	public void DestruirObjeto()
	{
		if (numero > -1) {
			Destroy(objetos[numero]);
			objetos = null;
			objetos = GameObject.FindGameObjectsWithTag("Obj");
			numero = objetos.Length - 1;
		}
	}
	public void Salir() {
		SceneManager.LoadScene("ProyectMenu");
		Application.Quit();
	}
}