using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.EvaulationSystem
{
    /// <summary>
    /// calculates the goal completion rating
    /// </summary>
    public class GoalCompletionManager : EvaluationManager
    {
      

        
        public override void Update()
        {
            currentRating = (int)(5 * GetPercentageOfCompletedTasks());
            base.Update();
        }
        public float GetPercentageOfCompletedTasks()
        {
            GoalManager goalManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>();
            Goal[] completedGoals = goalManager.GetCompletedGoals();
            Goal[] currentActiveGoals = goalManager.GetGoals();

            if(currentActiveGoals.Length == 0)
            {
                return 1;
            }
            else
            {
                return (completedGoals.Length / currentActiveGoals.Length + completedGoals.Length);
            }
        }

    }
}