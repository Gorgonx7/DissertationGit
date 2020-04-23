using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace Util.Interactables
{
    /// <summary>
    /// Script attatched to hand to control the grabbing of objects
    /// </summary>
    public class Grabber : InteractableCollision
    {
        Grabable grabbedObject = null;
        private Grabable ObjectInRange = null;
        
      

        

        protected override void OnTriggerEnter(Collider other)
        {

            if (grabbedObject == null && other.gameObject.GetComponent<Grabable>() != null)
            {

                ObjectInRange = other.gameObject.GetComponent<Grabable>();
            }
            if (other.gameObject.GetComponent<GraphicsTrigger>() != null)
            {

            }
        }
        protected void OnTriggerStay(Collider other)
        {
            if (grabbedObject == null && other.gameObject.GetComponent<Grabable>() != null)
            {

                ObjectInRange = other.gameObject.GetComponent<Grabable>();
            }
        }
        protected override void OnTriggerExit(Collider other)
        {
            ObjectInRange = null;
        }

        public override void LogEvent()
        {
            throw new System.NotImplementedException();
        }

        public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (ObjectInRange != null && grabbedObject == null)
            {
                if (ObjectInRange.GetComponent<GraphicsTrigger>() == null)
                {
                    ObjectInRange.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
                    ObjectInRange.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    ObjectInRange.Grab(gameObject.transform);
                    grabbedObject = ObjectInRange;

                    ObjectInRange = null;
                }

            }
        }

        public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (grabbedObject != null)
            {
                grabbedObject.gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
                grabbedObject.Drop();
                grabbedObject = null;
            }
        }
    }
}