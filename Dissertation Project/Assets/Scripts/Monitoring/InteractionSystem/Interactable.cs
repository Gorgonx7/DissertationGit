using ACE.TimeManagement;
using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Util.Interactables;
using System;

namespace ACE.Interactions {
    /// <summary>
    /// Responsible for updating the interact systems within the function. generates events within the interaction system whenever an interaction occours
    /// </summary>
    public class Interactable : InteractableCollision
    {
        private HintManager hintControl;
        // Start is called before the first frame update
        public DateTime timeLastInteracted;
        public float timeSinceInteracted;
        public override void Start()
        {

            hintControl = GameObject.FindGameObjectWithTag("HintManager").GetComponent<HintManager>();
            base.Start();
        }


        private void Update()
        {
            timeSinceInteracted += Time.deltaTime;
        }
        public override void LogEvent()
        {
            // Not needed for this function as each interaction has its own logs
        }

        public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (isHandNear)
            {
                timeSinceInteracted = 0;
                LogManager.Log("interacted With: " + gameObject.name);
                if (hintControl.doesCurrentFlashingContain(gameObject.transform.parent.gameObject))
                {
                    hintControl.ResetFlash();

                }
                InteractionManager.registerInteraction(gameObject);
            }
        }

        public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (isHandNear)
            {
                timeSinceInteracted = 0;
                LogManager.Log("stopped interacted With: " + gameObject.name);
                InteractionManager.registerInteraction(gameObject);
            }
        }
    }
}