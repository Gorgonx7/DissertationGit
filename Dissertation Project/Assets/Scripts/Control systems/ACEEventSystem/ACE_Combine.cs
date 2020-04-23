using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Event_System
{
    /// <summary>
    /// Similar to ACE_Action yet this only triggers when one object collides with another
    /// </summary>
    class ACE_Combine : MonoBehaviour
    {
        public List<GameObject> CombineableObjects = new List<GameObject>();
        public List<string> ListOfCombineObjectsNames = new List<string>();
        
        public string StateString = "";

        public string statetoremove= "";
        // AceEvent Name
        public string combineName = "";
        ACE_Event m_Event = null;
        private void Start()
        {

            foreach(string i in ListOfCombineObjectsNames)
            {
                GameObject holder = GameObject.Find(i);

                if (holder != null) {
                    CombineableObjects.Add(holder);
                }
            }
        }
      
        private void OnTriggerEnter(Collider other)
        {
            if (enabled)
            {
                if (CombineableObjects.Contains(other.gameObject))
                {
                    if (m_Event == null)
                    {
                        m_Event = new ACE_Event(combineName, other.gameObject, gameObject, EventType.Combine);
                        GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>().Receive(m_Event);
                    }
                }
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (enabled)
            {
                if (CombineableObjects.Contains(other.gameObject))
                {
                    if (m_Event != null)
                    {
                        GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>().End(m_Event);
                        m_Event = null;
                    }
                }
            }
        }
       
        public void Trigger(GameObject askingObject)
        {
            if (enabled)
            {
                if (statetoremove != "")
                {
                    askingObject.GetComponent<ACE_StateMachine>().subtract(statetoremove);
                }
                askingObject.GetComponent<ACE_StateMachine>().add(StateString);
            }
        }
    }
}
