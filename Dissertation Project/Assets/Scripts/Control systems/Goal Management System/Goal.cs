using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.Goals
{

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
        // Start is called before the first frame update
        void Start()
        {

        }
        
        // Update is called once per frame
        void Update()
        {
            if(GameObject.Find(GoalObjectName) != null)
            {
                GoalManager.Complete(this);
            }
        }
    }
}
