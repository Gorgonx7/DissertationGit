using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.EvaulationSystem { 
    /// <summary>
    /// Base class for evaluation metrics
    /// </summary>
    public abstract class EvaluationManager : MonoBehaviour
    {

        public HowToImproveController HTIController;
        public RatingController ratingController;
        public int currentRating = 0;
        protected List<string> currentImprovementPoints = new List<string>();
        public virtual void Update()
        {
            ratingController.SetRating(currentRating);
            HTIController.UpdateWaysToImprove(currentImprovementPoints.ToArray());
        }


    }
}
