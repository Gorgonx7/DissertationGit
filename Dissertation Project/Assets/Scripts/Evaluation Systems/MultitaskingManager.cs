using ACE.Goals;
using ACE.Groups;
using ACE.TimeManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.EvaulationSystem
{
    /// <summary>
    /// The multitasking manager calculates the amount the user has been multitasking within the application
    /// </summary>
    public class MultitaskingManager : EvaluationManager
    {
        HintManager hintManager;
        GroupUpdate groupManager;
        public bool organized = false;
       // Start is called before the first frame update
       void Start()
        {
            hintManager = GameObject.FindGameObjectWithTag("HintManager").GetComponent<HintManager>();
            groupManager = GameObject.FindGameObjectWithTag("GroupSystem").GetComponent<GroupUpdate>();
        }

        // Update is called once per frame
        public override void Update()
        {
            int output = 0;
            base.currentImprovementPoints.Clear();
            AttentionType typeOfAttention = getTypeOfAttention();
            if(hintManager.GetListOfActiveGoals().Count == 1)
            {
                organized = true;
                output += 2;
            }
            else
            {
                switch (typeOfAttention)
                {
                    case AttentionType.singleTask:
                        output += 1;
                        currentImprovementPoints.Add("Try to work on more than one task as you go");
                        currentImprovementPoints.Add("If you see an object that is related to another task try to place that near other items");

                        break;
                    case AttentionType.multiTask:
                        output += 2;
                        break;
                }
            }

            if (organized)
            {
                output += 3;
            }
            else
            {
                currentImprovementPoints.Add("Try to group items together as you go");

            }
            base.currentRating = output;
            

        }
        public AttentionType getTypeOfAttention()
        {
            List<Goal> hintGoalList = hintManager.GetListOfActiveGoals();
            List<Group> groups = groupManager.GetGroups();
            int singleGroups = 0;
            int logicalGroups = 0;
            int randomGroups = 0;
            if(hintGoalList.Count == 1)
            {
                organized = true;
                return AttentionType.singleTask;
            }
            foreach(Group i in groups)
            {
                switch (i.CheckIfGroupIsLogical())
                {
                    case GroupType.singleItem:
                        singleGroups++;
                        break;
                    case GroupType.logical:
                        logicalGroups++;
                        break;
                    case GroupType.random:
                        randomGroups++;
                        break;
                }
            }
            if (singleGroups > logicalGroups)
            {
                organized = false;
                // most likely single tasking with ok planning 
                return AttentionType.singleTask;
            }
            else if (randomGroups > logicalGroups)
            {
                organized = false;

                // lots of random groups that don't make sence,
                return AttentionType.multiTask;
            }
            else if (randomGroups < logicalGroups)
            {
                organized = true;

                return AttentionType.multiTask;
            }
            else if (singleGroups > randomGroups)
            {
                organized = true;
                // most likely just started the experiment so return single task for now
                return AttentionType.singleTask;
            }

            return AttentionType.singleTask;
        }
    }
}
