using ACE.Groups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.EvaulationSystem
{
    /// <summary>
    /// The organization manager use the grouping system to calculate the organization of the current attempt
    /// </summary>
    public class OrganizationManager : EvaluationManager
    {
        GroupUpdate groupManager;
       
        void Start()
        {
            currentImprovementPoints.Clear();
            groupManager = GameObject.FindGameObjectWithTag("GroupSystem").GetComponent<GroupUpdate>();

        }

        // Update is called once per frame
        public override void Update()
        {
            currentRating = (int)Mathf.Floor(5 * RateOrganization());
            base.Update();
        }
        public float RateOrganization()
        {
            List<Group> groups = groupManager.GetGroups();
            int singleGroups = 0;
            int logicalGroups = 0;
            int randomGroups = 0;
            foreach (Group i in groups)
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
            if(randomGroups > logicalGroups)
            {
                currentImprovementPoints.Add("Try to place objects together that are  as you go");
            }
            if (randomGroups > 0 || singleGroups > 0)
            {
                
                return (logicalGroups / singleGroups + randomGroups);
            }
            else
            {
                return 1;
            }

            
        }
    }
}