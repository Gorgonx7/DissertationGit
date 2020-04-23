using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.Event_System
{
    /// <summary>
    /// The ACE state machine contains the state of an object relative to the event system
    /// </summary>
    public class ACE_StateMachine : MonoBehaviour
    {
        // All objects have an initial state, which is set to their name
        public string initialState;
        public List<string> currentStates = new List<string>();
        public Dictionary<string, string> stateChanges = new Dictionary<string, string>();
        public bool changeNameOnStateChange = false;
        void Start()
        {
            initialState = gameObject.name;
            currentStates.Add(initialState);
        }
        /// <summary>
        /// returns all states
        /// </summary>
        /// <returns></returns>
        public List<string> getStates()
        {
            return currentStates;
        }
        /// <summary>
        /// adds a state to the state system
        /// </summary>
        /// <param name="state"></param>
        public void add(string state)
        {
            
            try
            {
                if (stateChanges[state] != null)
                {
                    currentStates.Remove(state);
                    currentStates.Add(stateChanges[state]);
                    gameObject.name = stateChanges[state];
                    
                }
            }
            catch
            {
                if (!currentStates.Contains(state))
                {
                    currentStates.Add(state);
                }
                if (changeNameOnStateChange)
                {
                    gameObject.name = state;
                }
            }
        }
        /// <summary>
        /// removes a state from the state system
        /// </summary>
        /// <param name="state"></param>
        public void subtract(string state)
        {
            if (currentStates.Contains(state))
            {
                currentStates.Remove(state);
            }
        }
        /// <summary>
        /// sets the state to the game objects name
        /// </summary>
        /// <param name="state"></param>
        public void setState(string state)
        {
            gameObject.name = state;
        }
        /// <summary>
        /// checks if the object has the specifiied state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
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