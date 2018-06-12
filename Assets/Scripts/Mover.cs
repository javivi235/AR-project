using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mover : MonoBehaviour {
    public EventSystem eventsistem;
    public GameObject selectedobject;
    private bool buttonselected;
	// Use this for initialization
	
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("IzquierdaVertical") != 0 && !buttonselected)
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
