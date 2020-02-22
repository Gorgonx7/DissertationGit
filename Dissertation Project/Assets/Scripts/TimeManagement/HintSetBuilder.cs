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
    /// This builds the hint data from goals, each object will flash when the hint button is pressed or hint timer expires
    /// This class is soley responsible for building sets alone, no other functionality belongs in this set
    /// </summary>
    class HintSetBuilder
    {
        public static HintData GetHints(Goal goal)
        {
            HintData data = new HintData();
            foreach(string GoalString in goal.importantItems)
            {
                if (GameObject.Find(GoalString) != null)
                {
                    data.ExistingHintObjects.Add(GoalString);
                }
                else
                {
                    data.DerivedHintObjects.Add(GoalString);
                }
            }

            return data;
        }
    }
}
