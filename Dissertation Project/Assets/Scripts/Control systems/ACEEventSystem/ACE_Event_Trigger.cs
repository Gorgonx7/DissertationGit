using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LogUtil;

namespace ACE.Event_System
{
    /// <summary>
    /// Used as the trigger for for the final event, in the case of the sample an explicit event has been triggered 
    /// </summary>
    public class ACE_Event_Trigger : MonoBehaviour
    {
        private ACE_Event_Controller Controller;
  
        public GameObject triggerModel;
        public string stateNameChange;
        public string ShaderProperty;
        public Color water;
        public Color milk;
        public Color Tea;
        public Color TeaWithMilk;
        public string completionState;
        void Start()
        {
            Controller = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>();
        }

        /// <summary>
        /// Requires some changes to ace action to change the state of an event based off of an event action, should not actually be that hard but ran out of time for the implementation
        /// </summary>
        void Update()
        {
            ACE_Event triggerEvent = Controller.Poll(gameObject);
            if (triggerEvent != null)
            {
                if (triggerEvent.getEventType() == EventType.Combine)
                {
                    triggerEvent.m_originalObject.GetComponent<ACE_Combine>().Trigger(gameObject);
                } else
                {
                    Trigger();
                }
            }
        }
        public void Trigger()
        {
            bool containsMilk = false;
            bool containsTea = false;
            foreach(string i in GetComponent<ACE_StateMachine>().getStates())
            {
                if (i.Contains("Milk"))
                {
                    containsMilk = true;
                }
                if (i.Contains("Teabag"))
                {
                    containsTea = true;
                }
            }
            if (containsMilk && containsTea)
            {
                triggerModel.GetComponent<Renderer>().material.color = TeaWithMilk;
            }
            else if (containsTea)
            {
                triggerModel.GetComponent<Renderer>().material.color = Tea;
            }
            else if (containsMilk)
            {
                triggerModel.GetComponent<Renderer>().material.color = milk;
            } else
            {
                triggerModel.GetComponent<Renderer>().material.color = water;
            }
            float currentvalue = triggerModel.GetComponent<Renderer>().material.GetFloat(ShaderProperty);
            if (currentvalue < 1.0f)
            {
                float valueToIncrement = 0.1f * Time.deltaTime;
                triggerModel.GetComponent<Renderer>().material.SetFloat(ShaderProperty, currentvalue + valueToIncrement);
            }
            else
            {
                
                LogManager.Log("State changed: " + gameObject.name + " in to " + stateNameChange);

                GetComponent<ACE_StateMachine>().add(completionState);
                GetComponent<ACE_StateMachine>().setState(completionState);
                Destroy(this);
            }
        }
    }
}
