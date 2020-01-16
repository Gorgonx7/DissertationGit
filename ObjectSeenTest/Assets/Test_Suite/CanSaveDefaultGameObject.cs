using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACE.FileSystem;
public class CanSaveDefaultGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject TestObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObjectCaretaker caretaker = new GameObjectCaretaker();
        caretaker.SaveObject(TestObject);
        //Load the object back in
        caretaker.LoadObject("test");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
