using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.EvaulationSystem
{
    public class GoalCompletionManager : EvaluationManager
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override void Update()
        {
            currentRating = (int)(5 * GetPercentageOfCompletedTasks());
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