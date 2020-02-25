using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Grabable : MonoBehaviour {

    public bool Grabbed = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
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
