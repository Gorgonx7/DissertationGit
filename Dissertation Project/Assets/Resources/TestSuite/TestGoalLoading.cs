#if(UNITY_EDITOR)
using ACE.Goals;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestGoalLoading : TestCase
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
        string[] fileNames = Directory.GetFiles("./UDO/Goals");
        string fileName = fileNames[0].Split('\\')[fileNames[0].Split('\\').Length - 1].Split('.')[0];
        
        GameObject manager = GameObject.FindGameObjectWithTag("Managers");
        Goal[] goalsLoaded = manager.GetComponents<Goal>();
        foreach(Goal i in goalsLoaded)
        {
            Destroy(i);
        }
        manager.GetComponent<GoalManager>().Load(fileName);
        goalsLoaded = manager.GetComponents<Goal>();
        if (goalsLoaded.Length  == 0)
        {
            failed = true;
        }
        foreach (Goal i in goalsLoaded)
        {
            Destroy(i);
        }
        base.Test();
    }
}
#endif
