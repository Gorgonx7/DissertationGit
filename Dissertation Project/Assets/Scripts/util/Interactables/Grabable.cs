using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
/// <summary>
/// used to specify that an object is grabable and detect when it has been grabbed or not
/// </summary>
public class Grabable : MonoBehaviour {

    public bool Grabbed = false;
   
    public void Grab(in Transform transforP)
    {
        gameObject.transform.parent.gameObject.transform.parent = transforP;
        Grabbed = true;
    }
    public void Drop()
    {
        gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
        gameObject.transform.parent.gameObject.transform.parent = null;
        Grabbed = false;
    }
    
}
