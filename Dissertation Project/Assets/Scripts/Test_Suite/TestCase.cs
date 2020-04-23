#if(UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestCase : MonoBehaviour
{
    public bool failed = false;
    public bool run = false;
    public string CaseName;
    public string errorLog;
    private void Start()
    {
        CaseName = this.GetType().ToString();
    }
    public virtual void Test()
    {
        gameObject.GetComponent<TestSuite>().complete(this);
        Debug.Log(CaseName + " Failed? " + failed);
        DestroyImmediate(this);
    }

}
#endif