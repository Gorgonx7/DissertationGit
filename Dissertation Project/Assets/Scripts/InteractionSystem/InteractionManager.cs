using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.InteractionSystem
{
    class InteractionManager : MonoBehaviour
    {
        List<Goal> activeGoalList = new List<Goal>();
        private void Start()
        {
            activeGoalList = GameObject.FindGameObjectWithTag("").GetComponent<GoalManager>().GetGoals().ToList();
        }

    }
}
