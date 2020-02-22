using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.TimeManagement
{
    class TimeSeenGetter
    {
        public float CalculateAttention(List<string> currentGoalItems)
        {
            List<SeenBehaviour> goalSeenBehaviours = new List<SeenBehaviour>();
            float output = 0.0f;
            foreach(string i in currentGoalItems)
            {
                goalSeenBehaviours.Add(GameObject.Find(i).GetComponent<SeenBehaviour>());
            }
            //lets add all those together and see what happens
            float totalTimeSepentLookingAtItems = 0.0f;
            float totalTimeItemsInPerifieral = 0.0f;
            float totalTimeItemsInCentre = 0.0f ;
            foreach(SeenBehaviour i in goalSeenBehaviours)
            {
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
            //TODO Refactor
            output = (fractionOfTimeInPeriferal * 0.25f) + (fractionOfTimeInCentre * 0.75f);
            // this currently produces a value between 0-1 so I need to refactor to generate a betteer 
            return output;
        }
    }
}
