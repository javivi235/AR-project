using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class uicontrol : MonoBehaviour {

    public GameObject menucrear;
    public GameObject menu2;
    public Animator animacionmenucrear;
    public Animator animacionmenuprincipal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Abrirmenucrear()
    {
       
        menucrear.SetActive(true);
        menu2.SetActive(false);
       // animacionmenuprincipal.SetBool("show", true);
        animacionmenucrear.SetBool("mostrar", true);


        
             

        // yield return new WaitForSeconds(animacion.clip.length);
    }
    public void Atrasmenu()
    {
        animacionmenucrear.SetBool("mostrar", false);
       // animacionmenuprincipal.SetBool("show", false);
        menu2.SetActive(true);
        menucrear.SetActive(false);
    }

}
