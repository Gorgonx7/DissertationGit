using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public GameObject GoalTextPrefab;
    public GameObject[] currentGoals = new GameObject[0];
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Goal[] goals = GameObject.FindGameObjectWithTag("TaskManager").GetComponents<Goal>();
        if(goals.Length != currentGoals.Length)
        {
            for(int i = 0; i < currentGoals.Length; i++)
            {
                Destroy(currentGoals[i]);
            }
            currentGoals = new GameObject[goals.Length];

            for (int g = 0; g < goals.Length; g++)
            {
                currentGoals[g] = Instantiate(GoalTextPrefab);
                currentGoals[g].transform.SetParent(gameObject.transform,false);
                currentGoals[g].GetComponent<Text>().text = goals[g].m_GoalName;
            }
        }
    }
}
