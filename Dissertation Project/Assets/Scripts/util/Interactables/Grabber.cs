using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Grabber : MonoBehaviour
{
    Grabable grabbedObject = null;
    private Grabable ObjectInRange = null;
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    // Start is called before the first frame update
    void Start()
    {
        control.AddOnStateDownListener(GrabDown, handType);
        control.AddOnStateUpListener(GrabUp, handType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(grabbedObject == null && other.gameObject.GetComponent<Grabable>() != null)
        {
            
            ObjectInRange = other.gameObject.GetComponent<Grabable>();
        }
        if(other.gameObject.GetComponent<GraphicsTrigger>() != null)
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (grabbedObject == null && other.gameObject.GetComponent<Grabable>() != null)
        {
            
            ObjectInRange = other.gameObject.GetComponent<Grabable>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ObjectInRange = null;
    }
    private void GrabDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        
        if(ObjectInRange != null && grabbedObject == null)
        {

            ObjectInRange.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
            ObjectInRange.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            ObjectInRange.Grab(gameObject.transform);
            grabbedObject = ObjectInRange;

            ObjectInRange = null;
            
        }
    }
    private void GrabUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if(grabbedObject != null)
        {
            grabbedObject.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            grabbedObject.Drop();
            grabbedObject = null;
        }
    }
}
