using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using ACE.Event_System;
public class doorOpen : MonoBehaviour
{
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    private bool isgrabbed = false;
    private bool isopen = false;
    public GameObject door;
    Quaternion initialRotation;
    private ACE_Event_Controller controller;
    private 
    // Start is called before the first frame update
    void Start()
    {
        control.AddOnStateDownListener(GrabDown, handType);
        initialRotation = door.transform.rotation;
        controller = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Grabber>() != null)
        {
            // we are being grabbed by a hand
            isgrabbed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Grabber>() != null)
        {
            // we are no longer being grabbed
            isgrabbed = false;
        }
    }
    private void GrabDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (isgrabbed)
        {
            if (isopen)
            {
                controller.Log(gameObject.transform.parent.name + " Closed");
                isopen = false;
                door.transform.rotation = initialRotation;
            }
            else if (!isopen)
            {
                controller.Log(gameObject.transform.parent.name + " Opened");
                isopen = true;
                door.transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, -90);
            }
        }
    }
    
}
