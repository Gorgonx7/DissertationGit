using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Event_System
{
    
    class ACE_Combine : MonoBehaviour, ACE_IEventTrigger
    {
        public List<GameObject> CombineableObjects;
        public string StateString;
        public string statetoremove;
        public string combineName;
        ACE_Event m_Event = null;
        private void Start()
        {
            if (combineName == "") throw new Exception("Combine name can not be equal to null");
        }
        private void Update()
        {
            
        }
        private void OnTriggerEnter(Collider other)
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
        
        private void OnTriggerExit(Collider other)
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
       
        public void Trigger(GameObject askingObject)
        {
            if(statetoremove != "")
            {
                askingObject.GetComponent<ACE_StateMachine>().subtract(statetoremove);
            }
            askingObject.GetComponent<ACE_StateMachine>().add(StateString);
        }
    }
}
