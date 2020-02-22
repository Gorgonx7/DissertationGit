using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LogUtil;
using UnityEditor;

public class TestSuite : MonoBehaviour
{
    // Start is called before the first frame update
    MonoScript[] scripts;
    int currentRunningTest = 0;
    bool allTestsCompleted = false;
    void Start()
    {
         scripts = Resources.LoadAll<MonoScript>("TestSuite");
        Component test = gameObject.AddComponent(scripts[0].GetClass());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void complete(TestCase test)
    {
        if (test.failed)
        {

            LogManager.Log("Test Case Failed " + test.CaseName + " Error Log: " + test.errorLog);
        }
        else
        {
            LogManager.Log("Test Case Passed" + test.CaseName);
        }
        if (!allTestsCompleted)
        {
            Destroy(test);
            currentRunningTest++;
            if (currentRunningTest >= scripts.Length)
            {
                LogManager.SaveLog();
                Destroy(this);
            }
            else
            {
                gameObject.AddComponent(scripts[currentRunningTest].GetClass());
            }
        }
    }
}
