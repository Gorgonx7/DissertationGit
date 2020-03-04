using ACE.Groups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.EvaulationSystem
{
    public class OrganizationManager : EvaluationManager
    {
        GroupUpdate groupManager;
        // Start is called before the first frame update
        void Start()
        {
            groupManager = GameObject.FindGameObjectWithTag("GroupSystem").GetComponent<GroupUpdate>();

        }

        // Update is called once per frame
        public override void Update()
        {

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
         
        }
    }
}