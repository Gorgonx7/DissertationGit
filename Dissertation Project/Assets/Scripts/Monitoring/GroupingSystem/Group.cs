﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.Groups {

    class Group
    {
        List<GroupItem> m_Items = new List<GroupItem>();
        public string groupName;

        public Group(string name, GroupItem item)
        {
            groupName = name;
            m_Items.Add(item);
            GameObject.FindGameObjectWithTag("Managers").GetComponent<GroupUpdate>().addToGroup(this);
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
            
            foreach(GroupItem i in m_Items)
            {
                if(i == null)
                {
                    m_Items.Remove(i);
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
    }
}
