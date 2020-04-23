using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.Event_System
{
    /// <summary>
    /// Used to specifiy the types of function that can be triggered after an event
    /// </summary>
    public class Event_Function
    {
        MethodInfo m_method;
        object[] m_value;
       

        public Event_Function(MethodInfo pMethod, object[] pValue)
        {
           
            m_method = pMethod;
            m_value = pValue;
        }
        public void Trigger(object m_objectToChange) {
            m_method.Invoke(m_objectToChange, m_value);
        }

    }
    /// <summary>
    /// Differentiates between this being a Action or Combine Event
    /// </summary>
    public enum EventType
    {
        Combine,
        Action

    }
    /// <summary>
    /// Main message carrier between most of the systems within ACE, capable of informing the classes of what is happening and how to react to this change
    /// </summary>
   public class ACE_Event
    {
        // Type of Event
        EventType m_eventType;
        // Triggering Function
        Event_Function m_eventFunction;
        // List of Effected Objects
        List<GameObject> m_gameObjects;
        //Original Object
        private GameObject _OriginalObject;
        // Event Name used for differentiating between events
        private string _EventName;
        /// <summary>
        /// Getter for original object, object that transmitted the event
        /// </summary>
        public GameObject m_originalObject { get { return _OriginalObject; } set { _OriginalObject = value; } }
        public string OriginatorName
        {
            set {  }
            get { return m_originalObject.name; }
        }
        public string EventName
        {
            set { _EventName = value; }
            get { return _EventName;  }
        }
        public string[] interactedObjectNames
        {
            set
            {
            }
            get {
                List<string> objectNames = new List<string>();
                foreach(GameObject i in m_gameObjects)
                {
                    objectNames.Add(i.name);
                }
                return objectNames.ToArray();
            }
        }
        /// <summary>
        /// This is the constructor for Ace Event general use with all defined parameters
        /// </summary>
        /// <param name="name">Name of the Event</param>
        /// <param name="pFunction"> Function for the event to execute</param>
        /// <param name="pPossibleEffectedObjects">Objects that might be effected by the event</param>
        /// <param name="pOriginator">Original object that generated the event</param>
        /// <param name="eType">type of event generated</param>
        public ACE_Event(string name, Event_Function pFunction, List<GameObject> pPossibleEffectedObjects, GameObject pOriginator, EventType eType)
        {
            m_eventFunction = pFunction;
            m_gameObjects = pPossibleEffectedObjects;
            m_originalObject = pOriginator;
            m_eventType = eType;
        }
        /// <summary>
        /// This is a reduced event call for ace combines mostly, as they only effect one game object
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="effectedObject"> effected game object</param>
        /// <param name="pOriginator">original game object creating the event</param>
        /// <param name="eType">type of event created</param>
        public ACE_Event(string name, GameObject effectedObject, GameObject pOriginator, EventType eType)
        {
            m_gameObjects = new List<GameObject>() { effectedObject };
            m_originalObject = pOriginator;
            m_eventType = eType;
        }
        /// <summary>
        /// Asks the original object to trigger the event cahnge
        /// </summary>
        /// <param name="AskingObject"></param>
        public void Trigger(GameObject AskingObject)
        {
            m_eventFunction.Trigger(AskingObject.GetComponent<Material>());
            
        }
        /// <summary>
        /// Checks if an event effects the given object
        /// </summary>
        /// <param name="askingObject"></param>
        /// <returns></returns>
        public bool Effects(GameObject askingObject)
        {
            return m_gameObjects.Contains(askingObject);
        }
        /// <summary>
        /// returns if it is a combine or action event
        /// </summary>
        /// <returns></returns>
        public EventType getEventType()
        {
            return m_eventType;
        }
    }
}
