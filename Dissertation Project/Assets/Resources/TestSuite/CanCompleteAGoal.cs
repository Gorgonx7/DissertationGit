using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Test_Suite
{
    class CanCompleteAGoal : TestCase
    {
        private Goal goalToTest;
        GameObject testCompletionObject;
        private void Start()
        {
            

            GameObject GoalControlObject = new GameObject("GoalTestEmpty");
            goalToTest = GoalControlObject.AddComponent<Goal>();
            GoalControlObject.GetComponent<Goal>().m_GoalName = "Test goal";
            GoalControlObject.GetComponent<Goal>().GoalObjectName = "Plane";
        }
        private void Update()
        {
            Test();
        }
        public override void Test()
        {
            if (goalToTest.completed == false)
            {
                Debug.Log("Initiating Goal Test");
                testCompletionObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                Debug.Log("Test Object Created Waiting for next update");

            } else if(GameObject.Find("Plane") != null)
            {
                failed = true;
                Destroy(testCompletionObject);
            }
            else
            {
                Destroy(testCompletionObject);
                Debug.Log("Test Completed, Goals Test Complete");

            }
            base.Test();
        }
    }
}
