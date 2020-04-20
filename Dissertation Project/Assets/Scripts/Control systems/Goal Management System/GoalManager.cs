using Assets.LogUtil;
using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //List of completed Goals
        private static List<Goal> completedGoals = new List<Goal>();
        private bool Loaded = false;
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
            Debug.Log("calledstart");
            
                Load(GlobalVariables.GoalXML);
            
        }
       
        public void Load(string filename)
        {
            GoalLoader.LoadGoal(filename, gameObject);
            Loaded = true;

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
        public Goal[] GetCompletedGoals()
        {
            return completedGoals.ToArray() ;
        }
        /// <summary>
        /// returns goal assocated with the game object, or null if no goal is associated with that object
        /// </summary>
        /// <param name="askingObject">object to ask for</param>
        /// <returns>goal or null</returns>
        public Goal GetGameObjectGoal(GameObject askingObject)
        {
            foreach(Goal i in GetComponents<Goal>())
            {
                if (i.importantItems.Contains(askingObject.name))
                {
                    return i;
                }
            }
            return null;
        }
    }
}