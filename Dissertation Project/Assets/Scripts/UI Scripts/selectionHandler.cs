using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Assets;
using static Valve.VR.InteractionSystem.CircularDrive;
using System;

public class selectionHandler : MonoBehaviour {
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    private GameObject collidedObject = null;
    // Use this for initialization
    void Start () {
        control.AddOnStateDownListener(EventDown, handType);
	}
    
   
	// Update is called once per frame
	void Update () {
       
	}
    private void OnTriggerEnter(Collider other)
    {
        collidedObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        collidedObject = null;
    }

    private void EventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        if (collidedObject != null)
        {
            collidedObject.GetComponent<SceneSwitcher>().switchScene();
        }
        Debug.Log("EventDown");
    }
   
}
