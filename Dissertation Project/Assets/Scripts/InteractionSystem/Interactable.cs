using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Interactable : MonoBehaviour
{
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    bool handNear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Grabber>() != null)
        {
            handNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Grabber>() != null)
        {
            handNear = false;
        }
    }
    private void GrabDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (handNear)
        {
            Debug.Log("interacted With: " + gameObject.name);
            
        }

    }
    private void GrabUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (handNear)
        {


        }

    }
}
