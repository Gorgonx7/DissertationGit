using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.TimeManagement
{
    /// <summary>
    /// A hint set is made up of each individual objects hint items
    /// responsible for updating the current objects with the scene and storted by the last time something within the goal changed
    /// </summary>
    class HintSet : MonoBehaviour, IComparable
    {
        public HintData m_Data;
        public List<GameObject> currentExistingData = new List<GameObject>();
        public Goal m_Goal;
        private bool isInited = false;
        private DateTime lastTimeChanged;
        public Material m_mat;
        private void Start()
        {
            
        }
        private void Update()
        {
            if (isInited && m_Goal != null)
            {
                
                foreach (string i in m_Data.ExistingHintObjects)
                {
                    if (GameObject.Find(i) == null)
                    {
                        // Object no longer exists
                        m_Data.PastObjects.Add(i);
                        m_Data.ExistingHintObjects.Remove(i);
                        currentExistingData.Remove(GameObject.Find(i));
                        lastTimeChanged = DateTime.Now;
                    }
                }
                foreach (string i in m_Data.DerivedHintObjects)
                {
                    GameObject objToFind = GameObject.Find(i);
                    if (objToFind != null)
                    {
                        currentExistingData.Add(objToFind);
                        m_Data.DerivedHintObjects.Remove(i);
                        m_Data.ExistingHintObjects.Add(i);
                        lastTimeChanged = DateTime.Now;

                    }
                }
                foreach (string i in m_Data.PastObjects)
                {
                    GameObject objToFind = GameObject.Find(i);

                    if (objToFind != null)
                    {
                        m_Data.PastObjects.Remove(i);
                        m_Data.ExistingHintObjects.Add(i);
                        currentExistingData.Add(objToFind);
                        lastTimeChanged = DateTime.Now;

                    }
                }
            }
        }
        public void init()
        {
            isInited = true;
            foreach (string i in m_Data.ExistingHintObjects)
            {
                currentExistingData.Add(GameObject.Find(i));
            }
           
        }
        public void flash()
        {
           
            
            foreach(GameObject i in currentExistingData)
            {
                // returns a copy of the current assigned materials
                Material[] currentMats = i.GetComponent<Renderer>().materials;
                List<Material> copy = new List<Material>();
                foreach(Material j in currentMats)
                {
                    copy.Add(j);
                }
                copy.Add(m_mat);
                i.GetComponent<Renderer>().materials = copy.ToArray();
            }
        }
        public void stopFlashing()
        {
            
           
            foreach (GameObject i in currentExistingData)
            {
                Material[] mats = i.GetComponent<MeshRenderer>().materials;
                List<Material> originalMat = mats.ToList();
                originalMat.RemoveAt(originalMat.Count - 1);
                i.GetComponent<MeshRenderer>().materials = originalMat.ToArray();
            }
        }
       
        public DateTime getLastInteractedTime()
        {
            return lastTimeChanged;
        }

        public int CompareTo(object obj)
        {
            HintSet other = obj as HintSet;
            // Most of these times may be between 0-1
            return lastTimeChanged.CompareTo(other.lastTimeChanged);

        }
        public bool effects(GameObject askingObject)
        {
            return m_Data.ExistingHintObjects.Contains(askingObject.name);
        }
    }
}
