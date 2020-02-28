﻿using ACE.TimeManagement;
using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Util.Interactables;
public class Interactable : InteractableCollision
{
    private HintManager hintControl;
    // Start is called before the first frame update
    public override void Start()
    {
       
        hintControl = GameObject.FindGameObjectWithTag("HintManager").GetComponent<HintManager>();
        base.Start();
    }



    public override void LogEvent()
    {
        // Not needed for this function as each interaction has its own logs
    }

    public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (isHandNear)
        {
            LogManager.Log("interacted With: " + gameObject.name);
            if (hintControl.doesCurrentFlashingContain(gameObject.transform.parent.gameObject))
            {
                hintControl.ResetFlash();
            }
        }
    }

    public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (isHandNear)
        {
            LogManager.Log("stopped interacted With: " + gameObject.name);

        }
    }
}
