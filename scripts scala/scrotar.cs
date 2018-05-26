using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class scrotar : MonoBehaviour,IVirtualButtonEventHandler {
   public GameObject vbButtonObject;
   public GameObject casa;


    

    // Use this for initialization
    void Start () {

        vbButtonObject = GameObject.Find("btmax");
        casa = GameObject.Find("casa");
        vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //vbButtonObject
	}
	
	// Update is called once per frame
	
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        casa.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        //transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        Debug.Log("abajo");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();

        //casa.transform.Rotate(new Vector3(0f, -30f, 0f) );
      //  casa.transform.Rotate(new Vector3(casa.transform.getro).StopAllCoroutines;
    }


}
