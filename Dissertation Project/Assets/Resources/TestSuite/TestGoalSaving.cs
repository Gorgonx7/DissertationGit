#if(UNITY_EDITOR)
using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGoalSaving : TestCase
{
    // Start is called before the first frame update
    void Start()
    {
        CaseName = this.GetType().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }
    public override void Test()
    {
        Goal goalToSave = gameObject.AddComponent<Goal>();
        goalToSave.name = "testgoal";
        goalToSave.GoalObjectName = "testName";
        goalToSave.importantItems = new List<string>() { "a", "weee", "test" };
        GoalSaveStruct savestruct = new GoalSaveStruct(goalToSave.name, goalToSave.GoalObjectName, goalToSave.importantItems.ToArray());
        GoalSaver.SaveGoal("testsuitegoalsave", new GoalSaveStruct[] { savestruct });
        GameObject manager = GameObject.FindGameObjectWithTag("Managers");
        manager.GetComponent<GoalManager>().Load("testsuitegoalsave");
        Goal[] loadedGoals = manager.GetComponents<Goal>();
        if(loadedGoals.Length == 1)
        {
            Goal testGoal = loadedGoals[0];
            if(testGoal.name != goalToSave.name || testGoal.GoalObjectName != goalToSave.GoalObjectName || testGoal.importantItems.Count != goalToSave.importantItems.Count)
            {
                failed = true;
            }
        }
        base.Test();
    }
}
#endif
