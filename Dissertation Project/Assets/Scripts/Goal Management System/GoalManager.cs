using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the root of the Task Management System, or the Goal System.
/// The objective of this system is to monitor the current scene for any changes in object state that may lead directly
/// to the completion of a goal.
/// The system also monitors the time between different goal steps. 
///     The system will measure the time between completing the next step of a goal
///     The time between the next step of any goal
///     The time to complete specific goals
///     total time spent on a goal (Active) within a scene
/// The system will output to the log system implemented in this same soloution
/// </summary>
/// 
namespace ACE.Goals
{
    public class GoalManager : MonoBehaviour
    {
        private static List<Goal> completedGoals = new List<Goal>();

        /// <summary>
        /// Static method that is called when a goal detects itself as complete
        /// </summary>
        public static void Complete(Goal goal)
        {
            completedGoals.Add(goal);
            LogManager.Log("Goal Complete: " + goal.name);
            goal.completed = true;
            UnityEngine.GameObject.Destroy(goal);
        }

        // Start is called before the first frame update
        void Start()
        {
            GoalLoader.LoadGoal("Sample", gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            Goal[] goals = GetComponents<Goal>();
            if(goals == null || goals.Length == 0){
                //TODO render summary UI and reset button
            }
        }
        private void OnApplicationQuit()
        {
            LogManager.SaveLog();
        }
        public Goal[] GetGoals()
        {
            return GetComponents<Goal>();
        }
      
    }
}