using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.IO;

public class Guardado : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbButtonObject;


    // Use this for initialization
    void Start()
    {

        vbButtonObject = GameObject.Find("Guardar");

        vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        GameObject name = GameObject.Find("Name");
        Nombre nombre = name.GetComponent<Nombre>();
        //Debug.Log(Nombre.proyecto);
        Debug.Log("Guardando");
        GameObject[] c = GameObject.FindGameObjectsWithTag("Obj");
        Debug.Log(c.Length);
            string fileName = "";
    	fileName = Application.persistentDataPath + "/" + Nombre.proyecto + ".txt" ;
        if (System.IO.File.Exists(fileName))
        {
            System.IO.File.Delete(fileName);
        }
	StreamWriter fileWriter = new StreamWriter(fileName, true);


        foreach (GameObject go in c)
        {

            fileWriter.WriteLine(go.transform.name + "|" + go.transform.position.x + "|" + go.transform.position.y + "|" +
            go.transform.position.z + "|" + go.transform.rotation.eulerAngles.x + "|" + go.transform.rotation.eulerAngles.y + "|" + go.transform.rotation.eulerAngles.z + "|" +
            go.transform.lossyScale.x + "|" + go.transform.lossyScale.y + "|" + go.transform.lossyScale.z + "\n");


        }
        fileWriter.Close();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}