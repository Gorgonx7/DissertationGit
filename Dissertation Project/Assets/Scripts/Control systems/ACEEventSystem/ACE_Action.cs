using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Reflection;
using System;

namespace ACE.Event_System
{
    /// <summary>
    /// Add more action trigger types here, each type needs to be defined with a type in the comment box below
    /// Rotation = Vector3
    /// Position = Vector3
    /// Collision = ComponentType
    /// </summary>
    public enum ACE_Action_Trigger_Type
    {
        Rotation, Postion, Collision, Interaction, Pull, Push, Grab_Rotation, State
    }
    /// <summary>
    /// An ACE action (Part of the action centred event system) 
    /// </summary>
    public class ACE_Action : MonoBehaviour
    {
        //Action Type
        public ACE_Action_Trigger_Type trigger_Type;
        //Target GameObject (If an object triggers when another object is in a specific position or colliding with a specific collision box)
        public GameObject target;
        //Action transform trigger, x y z, rotation or position
        public Vector3 transformTrigger;
        //Grab Handle for grab event types
        public Grabable GrabTrigger;
        //Sets if the less than triggers should be used
        public bool invert;
        //Sets if X Y or Z matters to the trigger
        public bool x_Matters, y_Matters, z_Matters;
        public bool UserDefined = false;
        public string requiredState = null;
        private ACE_Event EmittingEvent;
        public ACE_Interaction interactionObject;
        public string InteractionBoxName = null;
        private delegate bool trigger();
        private trigger Trigger;
        ACE_Event_Controller controller;
        public string actionName;
        List<GameObject> previousFrameInteractedObjects = new List<GameObject>();
        /// <summary>
        /// This function is used by the object builder to configure an ace action after it is saved
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="targetObject"></param>
        /// <param name="transformTrigger"></param>
        /// <param name="grabTrigger"></param>
        /// <param name="inverted"></param>
        /// <param name="xMat"></param>
        /// <param name="yMat"></param>
        /// <param name="zMat"></param>
        /// <param name="requiredState"></param>
        /// <param name="iteractBox"></param>
        public void ConfigureAction(string actionName, GameObject targetObject, Vector3 transformTrigger, Grabable grabTrigger, bool inverted, bool xMat, bool yMat, bool zMat, string requiredState, ACE_Interaction iteractBox)
        {
            this.InteractionBoxName = iteractBox.name;
            this.actionName = actionName;
            target = targetObject;
            this.transformTrigger = transformTrigger;
            this.GrabTrigger = grabTrigger;
            this.invert = inverted;
            this.x_Matters = xMat;
            this.y_Matters = yMat;
            this.z_Matters = zMat;
            this.requiredState = requiredState;
            
        }
        /// <summary>
        /// Used to set the triger and state of inverse, designed for ace action to not work if not called
        /// </summary>
        /// <param name="inverse"></param>
        public void setTrigger(bool inverse)
        {

            UserDefined = true;    
            invert = inverse;

            
        }
        void Start()
        {
            if(UserDefined)
            {
                trigger_Type = ACE_Action_Trigger_Type.Grab_Rotation;
            }
            if (enabled)
            {
                if (InteractionBoxName != null && InteractionBoxName != "")
                {
                    interactionObject = GameObject.Find("InteractionBoxName").GetComponent<ACE_Interaction>();
                }
                if (invert)
                {
                    switch (trigger_Type)
                    {
                        case ACE_Action_Trigger_Type.Rotation:
                            Trigger = invertIsTriggeredRotation;
                            break;
                        case ACE_Action_Trigger_Type.Grab_Rotation:
                            Trigger = invertIsTriggeredGrabRotation;
                            break;
                    }

                }
                else
                {
                    switch (trigger_Type)
                    {
                        case ACE_Action_Trigger_Type.Rotation:
                            Trigger = isTriggeredRotation;
                            break;
                        case ACE_Action_Trigger_Type.Grab_Rotation:
                            Trigger = isTriggeredGrabRotation;
                            break;
                    }

                }

                
                if (GameObject.FindGameObjectWithTag("ACE_Controller") != null)
                {
                    controller = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>(); 
                }
            }
        }

        /// <summary>
        /// Polls the trigger once per frame, then transmits an event if event is triggered
        /// </summary>
        void Update()
        {
            if (enabled)
            {
                List<GameObject> interactedObjects = new List<GameObject>();

                if (requiredState != null && requiredState != "")
                {
                    if (!GetComponent<ACE_StateMachine>().hasState(requiredState))
                    {
                        return;
                    }
                }
                if (Trigger())
                {
                    interactionObject.gameObject.SetActive(true);
                    interactedObjects = interactionObject.effectedObjects();
                }
                bool HasInteractedObjectsChanged = false;
                List<GameObject> holder = new List<GameObject>(); ;
                foreach (GameObject i in interactedObjects)
                {

                    if (!previousFrameInteractedObjects.Contains(i))
                    {
                        HasInteractedObjectsChanged = true;
                    }
                    else
                    {
                        holder.Add(i);
                    }

                }
                if (holder.Count != previousFrameInteractedObjects.Count)
                {
                    HasInteractedObjectsChanged = true;
                }
                if (HasInteractedObjectsChanged)
                {
                    controller.End(EmittingEvent);
                    EmittingEvent = null;
                }
                if ((Trigger() && EmittingEvent == null && interactedObjects.Count != 0))
                {


                    EmittingEvent = new ACE_Event(actionName, new Event_Function(typeof(Material).GetMethod("SetFloat", new Type[] { typeof(string), typeof(float) }), new object[] { "Fill", 1 }), interactedObjects, gameObject, EventType.Action);
                    controller.Receive(EmittingEvent);
                }
                else if (!Trigger() && EmittingEvent != null)
                {
                    interactionObject.gameObject.SetActive(false);
                    controller.End(EmittingEvent);
                    EmittingEvent = null;
                }
                previousFrameInteractedObjects = interactedObjects;
            }
        }
        /// <summary>
        /// Below functions are used to configure different types of trigger, more triggers could be developed but these were chosen to fulfill basic functionallity
        /// </summary>
        /// <returns></returns>
        private bool isTriggeredRotation()
        {

            if (x_Matters && target.transform.rotation.eulerAngles.x > transformTrigger.x)
            {
                return true;
            }
            if (y_Matters && target.transform.rotation.eulerAngles.y > transformTrigger.y)
            {
                return true;
            }
            if (z_Matters && target.transform.rotation.eulerAngles.z > transformTrigger.z)
            {
                return true;
            }
            return false;
        }
        private bool invertIsTriggeredRotation()
        {
            if (x_Matters &&  target.transform.rotation.eulerAngles.x < 360 - transformTrigger.x)
            {
                return true;
            }
            if (y_Matters && target.transform.rotation.eulerAngles.y < 360 - transformTrigger.y)
            {
                return true;
            }
            if (z_Matters && target.transform.rotation.eulerAngles.z < 360 - transformTrigger.z)
            {
                return true;
            }
            return false;
        }
        private bool isTriggeredGrabRotation()
        {
            if (GrabTrigger.Grabbed)
            {
                if (x_Matters && target.transform.parent.rotation.eulerAngles.x > transformTrigger.x)
                {
                    return true;
                }
                if (y_Matters && target.transform.parent.rotation.eulerAngles.y > transformTrigger.y)
                {
                    return true;
                }
                if (z_Matters && target.transform.parent.rotation.eulerAngles.z > transformTrigger.z)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool invertIsTriggeredGrabRotation()
        {
            if (GrabTrigger.Grabbed)
            {
                if (x_Matters && target.transform.parent.rotation.eulerAngles.x < 360 - transformTrigger.x)
                {
                    return true;
                }
                if (y_Matters && target.transform.parent.rotation.eulerAngles.y < 360 - transformTrigger.y)
                {
                    return true;
                }
                if (z_Matters && target.transform.parent.rotation.eulerAngles.z < 360 - transformTrigger.z)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}