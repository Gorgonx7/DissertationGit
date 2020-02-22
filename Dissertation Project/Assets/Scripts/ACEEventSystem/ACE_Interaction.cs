using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.Event_System
{
    public class ACE_Interaction : MonoBehaviour
    {
        //An ace interaction works using a collider to get all the effected objects, 
        // Start is called before the first frame update
        List<GameObject> currentInteracted = new List<GameObject>();
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public List<GameObject> effectedObjects()
        {
            return currentInteracted;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!currentInteracted.Contains(other.gameObject))
            {
                currentInteracted.Add(other.gameObject);
            }


        }
        private void OnTriggerExit(Collider other)
        {
            if (currentInteracted.Contains(other.gameObject))
            {
                currentInteracted.Remove(other.gameObject);
            }
        }
    }
}