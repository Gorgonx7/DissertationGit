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
    /// Two options in this class, manual hit tigger and automatic hit triggering, the time for hit triggering will be of type float, and adjustable in the UI, the default will be 5 minutes but this can be updated at any time throughout the simulation and triggered manually
    /// </summary>
    class HintManager : MonoBehaviour
    {
        DateTime m_SimStartTime;
        List<HintSet> hintSet = new List<HintSet>();
        private void Start()
        {
            m_SimStartTime = DateTime.Now;
            List<Goal> goals = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>().GetGoals().ToList();
            foreach(Goal i in goals)
            {
                HintSet holder = gameObject.AddComponent<HintSet>();
                holder.m_Data = HintSetBuilder.GetHints(i);
                holder.init();
            }
        }

        private void Update()
        {
            
        }


    }
}
