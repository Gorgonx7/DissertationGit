using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using ACE.Event_System;
using Assets.LogUtil;

namespace Util.Interactables
{
    public class DoorOpen : InteractableCollision
    {
      
        private bool isgrabbed = false;
        private bool isopen = false;
        public GameObject door;
        Quaternion initialRotation;
        private ACE_Event_Controller controller;
        // Start is called before the first frame update
        public override void Start()
        {
            initialRotation = door.transform.rotation;
            controller = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>();
            base.Start();
        }

       
      
       

        public override void LogEvent()
        {
            LogManager.Log("Opened door");
        }

        public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
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

        public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            //Not Required for this event
        }
    }
}
