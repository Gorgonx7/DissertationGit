using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.Groups {
    public enum GroupType
    {
        logical, random, singleItem
    }
    class Group
    {
        List<GroupItem> m_Items = new List<GroupItem>();
        public string groupName;
        public GroupType groupType;
        public Group(string name, GroupItem item)
        {
            groupName = name;
            m_Items.Add(item);
            GameObject.FindGameObjectWithTag("GroupSystem").GetComponent<GroupUpdate>().addToGroup(this);
        }
        public void initialiseGroups(List<string> items)
        {
            cleanItems();
            foreach (string i in items)
            {
                GameObject groupableObject = GameObject.Find(i);

            }
        }
        public int GetNumberOfMembers()
        {
            cleanItems();
            return m_Items.Count;
        }
        public List<GroupItem> GetItems()
        {
            cleanItems();
            return m_Items;
        }
        public Vector3 GetGroupCenter()
        {
            cleanItems();
            Vector3 output = new Vector3();
            foreach(GroupItem i in m_Items)
            {
                output += i.transform.position;
            }
            output /= m_Items.Count;
            return output;

        }
        public void addItem(GroupItem item)
        {
            cleanItems();
            m_Items.Add(item);
        }
        public void removeItem(GroupItem item)
        {
            cleanItems();
            m_Items.Remove(item);
        }
        private void cleanItems()
        {
            List<GroupItem> itemsToRemove = new List<GroupItem>(); 
            List<GroupItem> itemsToDestroy = new List<GroupItem>();
            
            foreach(GroupItem i in m_Items)
            {
                if(i == null)
                {
                    itemsToRemove.Add(i);
                    
                }
                else if(i.gameObject.GetComponents<GroupItem>().Length > 1)
                {
                    itemsToRemove.Add(i);
                    itemsToDestroy.Add(i);
                    
                }
            }
            foreach(GroupItem i in itemsToRemove)
            {
                m_Items.Remove(i);
                if (itemsToDestroy.Contains(i))
                {
                    i.remove();
                }
            }


        }
        public void CheckGroupMembership()
        {
            cleanItems();

            Vector3 Centroid = GetGroupCenter();
            Collider[] groupCollisions = Physics.OverlapSphere(Centroid, 3);
            List<GameObject> objectsStillInGroup = new List<GameObject>();
            foreach(Collider j in groupCollisions)
            {
                objectsStillInGroup.Add(j.gameObject);
            }
            List<GroupItem> itemsToRemove = new List<GroupItem>();
            foreach(GroupItem i in m_Items)
            {
                if (!objectsStillInGroup.Contains(i.gameObject))
                {
                    itemsToRemove.Add(i);
                    i.m_Group = new Group(i.gameObject.name, i);
                    i.groupName = i.m_Group.groupName;

                }
            }
            foreach(GroupItem i in itemsToRemove)
            {
                m_Items.Remove(i);
                i.m_Group = new Group(i.gameObject.name, i);
                i.groupName = i.m_Group.groupName;
            }
        }
        public GroupType CheckIfGroupIsLogical()
        {
            if(m_Items.Count == 1)
            {
                groupType = GroupType.singleItem;
                return groupType;
            }
            GoalManager manager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>();
            List<Goal> listOfGoals = new List<Goal>();
            foreach(GroupItem i in m_Items)
            {
                Goal j = manager.GetGameObjectGoal(i.gameObject);
                if(j != null)
                {
                    listOfGoals.Add(j);
                }
            }
            List<int> numberOfTimeGoalOccours = new List<int>();
            List<Goal> currentCheckedGoals = new List<Goal>();
            foreach(Goal i in listOfGoals)
            {
                if (currentCheckedGoals.Contains(i))
                {
                    continue;
                }
                currentCheckedGoals.Add(i);
                int numberOfTimesOcoured = 0;
                foreach(Goal j in listOfGoals) {
                    if(i == j)
                    {
                        numberOfTimesOcoured++;
                    }
                }
                numberOfTimeGoalOccours.Add(numberOfTimesOcoured);
            }
            if(numberOfTimeGoalOccours.Count > 2)
            {
                groupType = GroupType.random;
            }
            else
            {
                groupType = GroupType.logical;
            }
            return groupType;
        }
    }
}
