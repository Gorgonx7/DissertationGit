using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;
using Valve.VR.InteractionSystem;

public class GraphicsTrigger : MonoBehaviour
{
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    bool handNear = false;
    bool triggered = false;
    private Quaternion originalTransform;
    // Start is called before the first frame update
    void Start()
    {
        control.AddOnStateDownListener(GrabDown, handType);
        originalTransform = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Grabber>() != null)
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
            if (triggered)
            {
                gameObject.transform.rotation = originalTransform;
                triggered = false;
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(originalTransform.eulerAngles + new Vector3(0, 90, 0));
                triggered = true;
            }
        }
        
    }
   
}
