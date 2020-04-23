using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ACE.EvaulationSystem
{
    /// <summary>
    /// produces an average for the final evaluation system
    /// </summary>
    public class FinalScoreManager : EvaluationManager
    {
        public AttentionManager attention;
        public GoalCompletionManager Goal;
        public MultitaskingManager multitasking;
        public OrganizationManager organization;


        // Update is called once per frame
        public override void Update()
        {
            currentRating = (attention.currentRating + Goal.currentRating + multitasking.currentRating + organization.currentRating) / 4;
            base.Update();
        }
    }
}
