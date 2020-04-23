#if(UNITY_EDITOR)
using ACE.FileSystem;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestObjectLoading : TestCase
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
        GameObjectCaretaker caretaker = new GameObjectCaretaker();
        string[] files = Directory.GetDirectories("./UDO/SaveFiles");
        string fileName = files[0].Split('\\')[1];
        GameObject TestObject = caretaker.LoadObject(fileName);
        if (TestObject == null)
        {
            failed = true;
        }
        DestroyImmediate(TestObject);
        base.Test();
    }
}
#endif
