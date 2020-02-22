using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Puller : MonoBehaviour
{
    Pullable pulledObject = null;
    private Pullable ObjectInRange = null;
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    // Start is called before the first frame update
    void Start()
    {
        control.AddOnStateDownListener(PullDown, handType);
        control.AddOnStateUpListener(GrabUp, handType);
    }

    // Update is called once per frame
    void Update()
    {
        if(pulledObject != null)
        {
            pulledObject.Pull(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(pulledObject == null && other.gameObject.GetComponent<Pullable>() != null)
        {

            ObjectInRange = other.gameObject.GetComponent<Pullable>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (pulledObject == null && other.gameObject.GetComponent<Pullable>() != null)
        {

            ObjectInRange = other.gameObject.GetComponent<Pullable>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ObjectInRange = null;
    }
    private void PullDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if(ObjectInRange != null && pulledObject == null)
        {

           
            ObjectInRange.Pull(gameObject);
            pulledObject = ObjectInRange;

            ObjectInRange = null;
            
        }
    }
    private void GrabUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if(pulledObject != null)
        {
           
            pulledObject.Released();
            pulledObject = null;
        }
    }
}
