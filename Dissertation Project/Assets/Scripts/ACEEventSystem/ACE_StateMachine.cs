using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.Event_System
{
    public class ACE_StateMachine : MonoBehaviour
    {
        
        public string initialState;
        public List<string> currentStates = new List<string>();
        // Start is called before the first frame update
        void Start()
        {
            initialState = gameObject.name;
            currentStates.Add(initialState);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<string> getStates()
        {
            return currentStates;
        }
        public void add(string state)
        {
            if (!currentStates.Contains(state))
            {
                currentStates.Add(state);
            }
        }
        public void subtract(string state)
        {
            if (currentStates.Contains(state))
            {
                currentStates.Remove(state);
            }
        }
        public void setState(string state)
        {
            gameObject.name = state;
        }
        public bool hasState(string state)
        {
            if (currentStates.Contains(state))
            {
                return true;
            }
            return false;
        }
    }
}