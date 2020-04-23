using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Assets;
using UnityEngine.UI;
using Assets.LogUtil;

namespace ACE.Event_System
{
    /// <summary>
    /// ACE Event Controller controls the ace event system, passing events between relevent objects
    /// </summary>
    public class ACE_Event_Controller : MonoBehaviour
    {
        //These lists are used for the monitoring systems to keep track of the duplicated events
        public List<string> Final_Event_List = new List<string>();
        private List<string> EmittingEventNames = new List<string>();
        public List<ACE_Event> EmittingEvents = new List<ACE_Event>();
        private List<string> duplicatedEventLog = new List<string>();
        private List<string> duplicatedEventGameObjectNames = new List<string>();
       
        
        /// <summary>
        /// Recieves events and checks if they are duplicated
        /// </summary>
        /// <param name="IncomingEvent"></param>
        public void Receive(ACE_Event IncomingEvent)
        { 
           
            if (!EmittingEventNames.Contains(IncomingEvent.EventName))
            {
                EmittingEventNames.Add(IncomingEvent.EventName);
                EmittingEvents.Add(IncomingEvent);
                LogManager.Log("Object Emitting: " + IncomingEvent.OriginatorName);
                if (Final_Event_List.Contains(IncomingEvent.EventName))
                {
                    // we have a duplicated event, something that has already been done, this may or may not be important
                    string output = "Duplicated Event Detected: Originator: " + IncomingEvent.OriginatorName;
                    duplicatedEventGameObjectNames.Add(IncomingEvent.OriginatorName);
                    
                    LogManager.Log(output);
                    foreach (string i in IncomingEvent.interactedObjectNames)
                    {
                        
                        duplicatedEventLog.Add(output + "interacted object: " + i);
                        duplicatedEventGameObjectNames.Add(i);    
                    }
                }
            }
        }
        /// <summary>
        /// Destroys an event and removes it from the lists
        /// </summary>
        /// <param name="IncomingEndSignal"></param>
        public void End(ACE_Event IncomingEndSignal)
        {
            if (EmittingEvents.Contains(IncomingEndSignal))
            {
                if (!Final_Event_List.Contains(IncomingEndSignal.EventName))
                {
                    Final_Event_List.Add(IncomingEndSignal.EventName);
                }
                EmittingEvents.Remove(IncomingEndSignal);
                EmittingEventNames.Remove(IncomingEndSignal.EventName);
            }
        }
        /// <summary>
        /// If an object asks if it is being effected, and it is, returns true
        /// </summary>
        /// <param name="askingObject"></param>
        /// <returns></returns>
        public ACE_Event Poll(GameObject askingObject)
        {
            foreach (ACE_Event Aevent in EmittingEvents)
            {
                if (Aevent.Effects(askingObject))
                {
                    
                    return Aevent;
                }
            }
            return null;
        }
        /// <summary>
        /// Used by monitoring to get the duplicated event names
        /// </summary>
        /// <returns></returns>
        public string[] GetListOfDuplicatedGameObjects()
        {
            return duplicatedEventGameObjectNames.ToArray();
        }

        public void Log(string logString)
        {
            duplicatedEventLog.Add(logString);
            
        }
    }
}