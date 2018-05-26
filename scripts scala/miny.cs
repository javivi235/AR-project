using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class miny : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbButtonObject;
    public GameObject casa;




    // Use this for initialization
    void Start()
    {

        vbButtonObject = GameObject.Find("btminy");
        casa = GameObject.Find("casa");
        vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    // Update is called once per frame

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        casa.transform.localScale += new Vector3(0f, 0f, -0.1f);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }


}

