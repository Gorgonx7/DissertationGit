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
    public class HintManager : MonoBehaviour
    {
        DateTime m_SimStartTime;
        List<HintSet> hints = new List<HintSet>();
        float TimeSinceLastHint = 0.0f;
        public float NewHintTime = 5.0f;
        public Material flashMaterial;
        public bool FirstRun = true;
        private HintSet currentFlashingSet;
        private void Start()
        {
            m_SimStartTime = DateTime.Now;
          
        }

        private void Update()
        {

            if (FirstRun)
            {
                List<Goal> goals = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>().GetGoals().ToList();
                foreach (Goal i in goals)
                {
                    HintSet holder = gameObject.AddComponent<HintSet>();
                    holder.m_Data = HintSetBuilder.GetHints(i);
                    holder.m_Goal = i;
                    holder.m_mat = flashMaterial;
                    holder.init();
                    hints.Add(holder);

                }
                FirstRun = false;
            }
            TimeSinceLastHint += Time.deltaTime;
            if(TimeSinceLastHint > NewHintTime)
            {
                if(currentFlashingSet != null)
                {
                    currentFlashingSet.stopFlashing();
                    currentFlashingSet = null;
                }
                List<HintSet> hintHolder = GetOrderedListOfHints();
                hintHolder[0].flash();
                currentFlashingSet = hintHolder[0];
                TimeSinceLastHint = 0.0f;
            }
        }
        /// <summary>
        /// returns all goals in order of most recently active 
        /// </summary>
        public List<Goal> GetListOfActiveGoals()
        {
            hints.Sort();
            List<Goal> orderedGoals = new List<Goal>();
            foreach(HintSet i in hints)
            {
                orderedGoals.Add(i.m_Goal);
            }
            return orderedGoals;
        }
        public void ResetFlash()
        {
            if (currentFlashingSet != null)
            {
                currentFlashingSet.stopFlashing();
                currentFlashingSet = null;
                TimeSinceLastHint = 0.0f;
            }
        }
        private List<HintSet> GetOrderedListOfHints()
        {
            hints.Sort();
            return hints;
        }
        public bool doesCurrentFlashingContain(GameObject askingObject)
        {
            if(currentFlashingSet != null)
            {
                return currentFlashingSet.effects(askingObject);
            }
            return false;
        }
    }
}
