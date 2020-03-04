using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Groups
{
    class GroupUpdate : MonoBehaviour
    {
        List<Group> m_Groups = new List<Group>();
        private void Start()
        {
            GameObject[] KeyObjects = GameObject.FindGameObjectsWithTag("KeyItems");
            foreach(GameObject i in KeyObjects)
            {
                i.AddComponent<GroupItem>();
            }
        }
        private void Update()
        {
            List<Group> groupsToRemove = new List<Group>();
            foreach(Group i in m_Groups)
            {
                
                if(i == null)
                {
                    groupsToRemove.Add(i);
                    
                    continue;
                }
                i.CheckGroupMembership();
                if(i.GetItems().Count == 0)
                {
                    groupsToRemove.Add(i);
                    
                }
            }
        }
        public void addToGroup(Group pGroup)
        {
            m_Groups.Add(pGroup);
        }
        public List<Group> GetGroups()
        {
            return m_Groups;
        }
    }
}
