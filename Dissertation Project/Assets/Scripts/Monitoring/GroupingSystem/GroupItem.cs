using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Groups
{
    class GroupItem : MonoBehaviour
    {
        public float StartRadius;
        private float m_Radius;
        public string groupName;
        public Group m_Group;
        private void Start()
        {
            if(m_Group == null)
            {
                m_Group = new Group(gameObject.name, this);
                
                
                groupName = m_Group.groupName;
            }
        }
        private void Update()
        {
            Vector3 centre = gameObject.transform.position;
            
            if(m_Group.GetNumberOfMembers() == 1)
            {
                m_Radius = StartRadius;
            }
            else
            {
                centre = m_Group.GetGroupCenter();
                
            }
            Collider[] surroundingObjects = Physics.OverlapSphere(centre, m_Radius);
            
            foreach(Collider i in surroundingObjects)
            {
                if(i.gameObject.GetComponent<KeyItem>() != null)
                {
                    GroupItem item = i.gameObject.GetComponent<GroupItem>();
                    
                    if(item == null)
                    {
                        item = i.gameObject.AddComponent<GroupItem>();
                    }
                    else
                    {
                        if (item.m_Group == m_Group)
                        {
                            continue;
                        }
                        item.m_Group.removeItem(item);
                        Destroy(item);
                        item = i.gameObject.AddComponent<GroupItem>();
                    }
                    item.m_Group = m_Group;
                    m_Group.addItem(item);
                    item.StartRadius = StartRadius;
                    item.groupName = m_Group.groupName;
                }
            }
            Collider[] localSurroundingObjects = Physics.OverlapSphere(gameObject.transform.position, m_Radius);
            
            foreach(Collider i in localSurroundingObjects)
            {
                if(i.GetComponent<GroupItem>() != null)
                {
                    return;
                }
            }
            m_Group.removeItem(this);
            m_Group = null;
            m_Group = new Group(gameObject.name, this);
        }
    }
}
