using Assets;
using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.Interactables;
using Valve.VR;

public class ConfigureHeight : IVREvent
{
  
    public GameObject HeadFollower;
    private bool triggered = false;
    public override void LogEvent()
    {
        
    }

    public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (this != null)
        {
            if (!triggered)
            {
                GlobalVariables.HeadsetHeight = HeadFollower.transform.position.y;

                GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SteamVR_LoadLevel>().enabled = true;
                Destroy(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }

    public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Not needed
    }
}
