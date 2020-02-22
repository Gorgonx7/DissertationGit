using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACE.FileSystem;
using System;

public class CanSaveDefaultGameObject : TestCase
{
    // Start is called before the first frame update
    void Start()
    {
        CaseName = this.GetType().ToString();

    }
    public override void Test()
    {
        try
        {
            GameObject TestObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            TestObject.GetComponent<BoxCollider>().size = new Vector3(5, 3, 1);
            TestObject.name = "test";
            GameObjectCaretaker caretaker = new GameObjectCaretaker();
            caretaker.SaveObject(TestObject);
            //Load the object back in
            if (caretaker.LoadObject("test") == null)
            {
                failed = true;
            }
        }
        catch (Exception e)
        {
            failed = true;
            errorLog = e.StackTrace;
        }
        base.Test();
    }
    // Update is called once per frame
    void Update()
    {
        Test();
    }
}
