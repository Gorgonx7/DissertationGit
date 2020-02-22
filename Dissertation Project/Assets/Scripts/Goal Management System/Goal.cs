using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.Goals
{

    public class Goal : MonoBehaviour
    {
        public string m_GoalName;
        public string GoalObjectName;
        public bool completed = false;
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
