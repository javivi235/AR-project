using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Guardado : MonoBehaviour
{
    public void Guardar()
    {
        //GameObject name = GameObject.Find("Name");
        //Nombre nombre = name.GetComponent<Nombre>();
        Debug.Log(Nombre.proyecto);
        Debug.Log("Guardando");
        GameObject[] c = GameObject.FindGameObjectsWithTag("Obj");
        Debug.Log(c.Length);
            string fileName = "";
        fileName = Application.persistentDataPath + "/" + Nombre.proyecto + ".txt" ;
        //Para pruebas en pc, comente la linea anterior y use la siguiente
        //fileName =  "Assets/" + Nombre.proyecto + ".txt";
        if (System.IO.File.Exists(fileName))
        {
            System.IO.File.Delete(fileName);
        }
	StreamWriter fileWriter = new StreamWriter(fileName, true);


        foreach (GameObject go in c)
        {
            Regex filtro = new Regex(@"\||\(Clone\)");
            string[] nombre = filtro.Split(go.transform.name);
            fileWriter.WriteLine(nombre[0] + "|" + go.transform.position.x + "|" + go.transform.position.y + "|" +
            go.transform.position.z + "|" + go.transform.rotation.eulerAngles.x + "|" + go.transform.rotation.eulerAngles.y + "|" + go.transform.rotation.eulerAngles.z + "|" +
            go.transform.lossyScale.x + "|" + go.transform.lossyScale.y + "|" + go.transform.lossyScale.z + "\n");


        }
        fileWriter.Close();
    }

}