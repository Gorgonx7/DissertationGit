﻿using System.Collections;
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
        public bool x_Matters;
        public bool y_Matters;
        public bool z_Matters;
        //Used to define a component type that a object has to have if a collision is present
        public Component componentType;
        public string requiredState = null;
        public ACE_Interaction trigger_Interaction;
        public ACE_Event EmittingEvent;
        public ACE_Interaction interactionObject;
        private delegate bool trigger();
        private trigger Trigger;
        ACE_Event_Controller controller;
        public string actionName;
        List<GameObject> previousFrameInteractedObjects = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {
            if (actionName == "") throw new Exception("Action name can not be set to null");
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

            controller = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>();
        }

        // Update is called once per frame
        void Update()
        {
            List<GameObject> interactedObjects = new List<GameObject>();
            if (Trigger())
            {
                interactionObject.gameObject.SetActive(true);
                interactedObjects = interactionObject.effectedObjects();
            }
            if(requiredState != null && requiredState != "")
            {
                if(!GetComponent<ACE_StateMachine>().hasState(requiredState))
                {
                    return;
                }
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
            if(holder.Count != previousFrameInteractedObjects.Count)
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
                
               
                EmittingEvent = new ACE_Event(actionName, new Event_Function(typeof(Material).GetMethod("SetFloat", new Type[] { typeof(string), typeof(float) }),  new object [] { "Fill", 1 }), interactedObjects, gameObject , EventType.Action);
                controller.Receive(EmittingEvent);
            }
            else if(!Trigger() && EmittingEvent != null)
            {
                interactionObject.gameObject.SetActive(false);
                controller.End(EmittingEvent);
                EmittingEvent = null;
            }
            previousFrameInteractedObjects = interactedObjects;
        }

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
            if (x_Matters && target.transform.rotation.eulerAngles.x < transformTrigger.x)
            {
                return true;
            }
            if (y_Matters && target.transform.rotation.eulerAngles.y < transformTrigger.y)
            {
                return true;
            }
            if (z_Matters && target.transform.rotation.eulerAngles.z < transformTrigger.z)
            {
                return true;
            }
            return false;
        }
        private bool isTriggeredGrabRotation()
        {
            if (GrabTrigger.Grabbed)
            {
                if (x_Matters && target.transform.parent.rotation.eulerAngles.x - 180 > transformTrigger.x)
                {
                    return true;
                }
                if (y_Matters && target.transform.parent.rotation.eulerAngles.y - 180 > transformTrigger.y)
                {
                    return true;
                }
                if (z_Matters && target.transform.parent.rotation.eulerAngles.z - 180 > transformTrigger.z)
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
                if (x_Matters && target.transform.parent.rotation.eulerAngles.x - 180 < transformTrigger.x)
                {
                    return true;
                }
                if (y_Matters && target.transform.parent.rotation.eulerAngles.y - 180 < transformTrigger.y)
                {
                    return true;
                }
                if (z_Matters && target.transform.parent.rotation.eulerAngles.z - 180 < transformTrigger.z)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}