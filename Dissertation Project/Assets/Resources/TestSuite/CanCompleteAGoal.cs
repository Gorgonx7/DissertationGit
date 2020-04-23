#if(UNITY_EDITOR)
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
            Goal hol = GoalControlObject.GetComponent<Goal>();
            hol.m_GoalName = "Test goal";
            hol.GoalObjectName = "Plane";
           
        }
        private void Update()
        {
            Test();
        }
        public override void Test()
        {
            if (goalToTest.completed == false )
            {
                Debug.Log("Initiating Goal Test");
                testCompletionObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                Debug.Log("Test Object Created Waiting for next update");
                

            } else if(GameObject.Find("Plane") != null && goalToTest != null)
            {
                failed = true;
                DestroyImmediate(testCompletionObject);
                base.Test();
                Destroy(this);
            }
            else
            {
                DestroyImmediate(testCompletionObject);
                Debug.Log("Test Completed, Goals Test Complete");
                base.Test();
                Destroy(this);
            }
            
            
        }
    }
}
#endif