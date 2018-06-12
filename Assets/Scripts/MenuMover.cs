using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuMover : MonoBehaviour {
    public EventSystem eventsistem;
    public GameObject selectedobject;
    private bool buttonselected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") !=0 && buttonselected ==false)
        {
            eventsistem.SetSelectedGameObject(selectedobject);
            buttonselected = true;
        }

	}
    private void OnDisable()
    {
        buttonselected = false;
    }
}