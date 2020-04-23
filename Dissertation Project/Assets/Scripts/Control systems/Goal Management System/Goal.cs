using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.Goals
{
    /// <summary>
    /// Goal class, just responsible for checking if this specific goal is complete
    /// </summary>
    public class Goal : MonoBehaviour
    {
        // the name of this goal
        public string m_GoalName;
        // The name of this goals target object
        public string GoalObjectName;
        // If the goal has been completed
        public bool completed = false;
        //Items associated with this goal
        public List<string> importantItems = new List<string>();
       
        
        /// <summary>
        /// Checks once per frame if the goal is complete
        /// </summary>
        void Update()
        {
            if(GameObject.Find(GoalObjectName) != null)
            {
                GoalManager.Complete(this);
            }
        }
    }
}
