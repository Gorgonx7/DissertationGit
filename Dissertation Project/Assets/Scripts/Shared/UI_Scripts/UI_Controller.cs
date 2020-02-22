using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

using Valve.VR.InteractionSystem;

public class UI_Controller : MonoBehaviour {
    public SteamVR_Action_Boolean plantAction;

    public Hand hand;
    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (plantAction == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned");
            return;
        }

        plantAction.AddOnChangeListener(OnPlantActionChange, hand.handType);
    }
    private void OnPlantActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
    {
        if (newValue)
        {
            Debug.Log("Event Triggered");
            //TODO add in spawning of prefab and translation to hand location
        }
    }
    // Use this for initialization
    void Start () {
	   	
	}
	
	// Update is called once per frame
	void Update () {
        
        

    }

}
