using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;
using Valve.VR.InteractionSystem;
namespace Util.Interactables
{
    public class GraphicsTrigger : InteractableCollision
    {
      
        public GameObject objectToActivate;

        bool triggered = false;
        private Quaternion originalTransform;
        // Start is called before the first frame update
        
        public override void Start()
        {
            
            originalTransform = gameObject.transform.rotation;
            base.Start();
        }

        public override void LogEvent()
        {
            throw new System.NotImplementedException();
        }

        public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (isHandNear)
            {
                if (triggered)
                {
                    gameObject.transform.rotation = originalTransform;
                    objectToActivate.SetActive(false);
                    triggered = false;
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(originalTransform.eulerAngles + new Vector3(0, 0, 90));
                    objectToActivate.SetActive(true);
                    triggered = true;
                }
            }
        }

        public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            // Not needed for this interaction
        }
    }
}