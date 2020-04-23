using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the Goal UI for the user, displaying all the goals in text form
/// </summary>
public class GoalUI : MonoBehaviour
{
    public GameObject GoalTextPrefab;
    public GameObject[] currentGoals = new GameObject[0];
   

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            Goal[] goals = GameObject.FindGameObjectWithTag("TaskManager").GetComponents<Goal>();
            if (goals.Length != currentGoals.Length)
            {
                for (int i = 0; i < currentGoals.Length; i++)
                {
                    Destroy(currentGoals[i]);
                }
                currentGoals = new GameObject[goals.Length];

                for (int g = 0; g < goals.Length; g++)
                {
                    currentGoals[g] = Instantiate(GoalTextPrefab);
                    currentGoals[g].transform.SetParent(gameObject.transform, false);
                    currentGoals[g].GetComponent<Text>().text = goals[g].m_GoalName;
                }
            }
        }
    }
}
