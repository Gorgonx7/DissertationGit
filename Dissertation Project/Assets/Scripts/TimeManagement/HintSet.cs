using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.TimeManagement
{
    class HintSet : MonoBehaviour
    {
        public HintData m_Data;
        public List<GameObject> currentExistingData = new List<GameObject>();
        private bool isInited = false;
        private void Start()
        {
            
        }
        private void Update()
        {
            if (isInited)
            {
                foreach (string i in m_Data.ExistingHintObjects)
                {
                    if (GameObject.Find(i) == null)
                    {
                        // Object no longer exists
                        m_Data.PastObjects.Add(i);
                        m_Data.ExistingHintObjects.Remove(i);
                        currentExistingData.Remove(GameObject.Find(i));
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

        }
        public bool Poll()
        {
            foreach(GameObject i in currentExistingData)
            {

            }
            return false;
        }
    }
}
