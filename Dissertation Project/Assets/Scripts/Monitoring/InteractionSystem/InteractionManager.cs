using ACE.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.Interactions
{
    static class InteractionManager
    {
        static List<Goal> orderedListOfGoals = new List<Goal>();
        static List<GameObject> orderedListOfGameObjects = new List<GameObject>();
        public static void registerInteraction(GameObject gameObj)
        {
            if(orderedListOfGameObjects.Count >= 5)
            {
                orderedListOfGameObjects.RemoveAt(0);
            }
            orderedListOfGameObjects.Add(gameObj);
            GoalManager man = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<GoalManager>();
            Goal holder = man.GetGameObjectGoal(gameObj);
            if (holder != null) {
                if (orderedListOfGoals.Contains(holder))
                {
                    orderedListOfGoals.Remove(holder);
                }
                orderedListOfGoals.Add(holder);
            }
            

        }
        public static List<Goal> GetInteractionOrderedList()
        {
            return orderedListOfGoals;
        }
        public static List<GameObject> GetGameObjectInteractionOrderedList()
        {
            return orderedListOfGameObjects;
        }
    }
}
