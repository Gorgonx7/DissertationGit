using ACE.Event_System;
using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace ACE.EvaulationSystem
{
    public enum AttentionType
    {
        multiTask,
        singleTask
    }
    /// <summary>
    /// Final class to pull together all information and calculate a rating for attention
    /// </summary>
    public class AttentionManager : EvaluationManager
    {
        public AttentionType attentionType;
        
        public int errorThreshold = 5;
       
        // Update is called once per frame
        public override void Update()
        {
            List<Goal> allGoals = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>().GetCompletedGoals().ToList();
            allGoals.AddRange(GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>().GetGoals());
            float totalSightComponent = 0.0f;
            foreach (Goal i in allGoals)
            {
                totalSightComponent += CalculateSightComponent(i);
            }
            totalSightComponent /= allGoals.Count;
            currentRating = (int)Mathf.Ceil(totalSightComponent + CalculateGoalComponent());
            base.Update();
        }
        /// <summary>
        /// Calculates the sight component of the evaluation
        /// </summary>
        /// <returns></returns>
        private float CalculateSightComponent(Goal pGoal)
        {

            List<SeenBehaviour> goalSeenBehaviours = new List<SeenBehaviour>();
            float output = 0.0f;
            foreach (string i in pGoal.importantItems)
            {
                GameObject holder = GameObject.Find(i);
                if (holder != null)
                {
                    goalSeenBehaviours.Add(holder.GetComponent<SeenBehaviour>());
                }
            }
            //lets add all those together and see what happens
            float totalTimeSepentLookingAtItems = 0.0f;
            float totalTimeItemsInPerifieral = 0.0f;
            float totalTimeItemsInCentre = 0.0f;
            foreach (SeenBehaviour i in goalSeenBehaviours)
            {
                if(i == null)
                {
                    continue;
                }
                totalTimeSepentLookingAtItems += i.GetTimeInFrame();
                totalTimeItemsInPerifieral += i.GetTimeInPeriferal();
                totalTimeItemsInCentre += i.GetTimeInFocus();
            }
            float timeSinceStart = Time.timeSinceLevelLoad;
            // so we know the attention to the task is some function of these three numbers, our goal is to quantify into a value betweeen 1-5 
            // first we can get the fraction of time that items have been in each respective view
            float fractionOfTimeInView = totalTimeSepentLookingAtItems / timeSinceStart;
            float fractionOfTimeInCentre = totalTimeItemsInCentre / timeSinceStart;
            float fractionOfTimeInPeriferal = totalTimeItemsInPerifieral / timeSinceStart;
            // so these values are all between 0-1,  however they are not a fully true value of attention because there may be influences such as search time, which could greatly inflate this value.
            // we need to work out how much time should be spent on this specific task to know how well they did with paying attention to it, we can figure this out by using the total time spent interacting with the objects as a guide
            // following the logic above, if we added them together they would be somevalue /3. which is a quater of this, multiply this by the magic value of 1.25

            output = (fractionOfTimeInPeriferal * 0.25f) + (fractionOfTimeInCentre * 0.75f);
            // this currently produces a value between 0-1 so I need to refactor to generate a better 
            return output;
        }
        /// <summary>
        /// This is the function for calculating how well the user is completing goals, and in what order, it returns a float and sets the enum attentionType dependent on if they are multitasking or not
        /// </summary>
        /// <returns> A rating between 0 and 2.5</returns>
        private float CalculateGoalComponent()
        {
            float output = 0.0f;
            // Work out if they have been looping
            string[] duplicatedObjectNames = GameObject.FindGameObjectWithTag("ACE_Controller").GetComponent<ACE_Event_Controller>().GetListOfDuplicatedGameObjects();
            int numberOfErrors = 0;
            foreach (string i in duplicatedObjectNames)
            {
                int numberOfTimesAppeared = 0;
                foreach (string j in duplicatedObjectNames)
                {
                    if (i == j)
                    {
                        numberOfTimesAppeared++;
                    }
                }
                if (numberOfTimesAppeared > 1)
                {
                    numberOfErrors++;
                }
            }
            if (numberOfErrors > errorThreshold)
            {
                currentImprovementPoints.Add("You are doing the same tasks several times, try to place things that you are done with away from everything else");
            }
            else
            {
                output += 2.0f;
            }

            return output;
        }


    }
}