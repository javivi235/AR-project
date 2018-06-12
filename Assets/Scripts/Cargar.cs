using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using System;
public class Cargar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("En la camara AR");
		
		try
        {
            GameObject Name = GameObject.Find("Name");
            Nombre nombre = Name.GetComponent<Nombre>();
	        Debug.Log("ARCHIVO A CARGAR: " + Nombre.proyecto);
            string path = Application.persistentDataPath + "/" + Nombre.proyecto +".txt";
            StreamReader reader = new StreamReader(path);
            string aux = "";
            ArrayList Lineas = new ArrayList();
            while (aux != null)
            {
                aux = reader.ReadLine();
                //Debug.Log(aux);
                if (aux != null && aux != "")
                    Lineas.Add(aux);

            }
            reader.Close();

            foreach (string linea in Lineas)
            {

                Debug.Log(linea);
                Regex filtro = new Regex(@"\|");
                string[] data = filtro.Split(linea);

                GameObject go = Instantiate(Resources.Load<GameObject>(data[0]));
		go.transform.SetParent(GameObject.Find("Gound Plane Stage").transform, false);
                go.transform.Translate(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
                go.transform.Rotate(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]));
                Vector3 v = new Vector3();
                v = go.transform.localScale;
                v.x = float.Parse(data[7]);
                v.y = float.Parse(data[8]);
                v.z = float.Parse(data[9]);
                go.transform.localScale = v;
                go.tag = "Obj";

            }

        }
        catch (Exception e)
        {
            Debug.Log("Error has occurred");
        
	}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
