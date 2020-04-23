#if(UNITY_EDITOR)
using ACE.Event_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNameStateChange : TestCase
{
    GameObject floor;
    GameObject cup;
    GameObject teabag;
    float timesincestart = 0;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        CaseName = this.GetType().ToString();
        floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3();
        cup = Resources.Load<GameObject>("BuildableObjects/Mug");
        teabag = Resources.Load<GameObject>("BuildableObjects/Teabag");
        cup = Instantiate(cup);
        teabag = Instantiate(teabag);
        cup.transform.position = new Vector3(0, 0.1f, 0);
        teabag.transform.position = new Vector3(0, 0.5f, 0);
        teabag.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        timesincestart += Time.deltaTime;
        if (Mathf.Floor(timesincestart) == 2 && first)
        {
            ACE_Combine comb = teabag.AddComponent<ACE_Combine>();
            comb.ListOfCombineObjectsNames = new List<string>(new string[] { "Mug(Clone)" });
            comb.StateString = "Teabag";
            comb.combineName = "addTeabag";
            cup.AddComponent<ACE_StateMachine>().changeNameOnStateChange = true;
            
            cup.AddComponent<ACE_Event_Trigger>();
            teabag.GetComponent<Rigidbody>().useGravity = true;
            first = false;
        }
        if (Mathf.Floor(timesincestart) == 5 && !first)
        {
            Test();
        }
    }
    public override void Test()
    {
        if (cup.GetComponent<ACE_StateMachine>().currentStates.Count != 2 || cup.name != teabag.GetComponent<ACE_Combine>().StateString)
        {
            failed = true;

        }
        Destroy(teabag);
        Destroy(cup);
        Destroy(floor);
        base.Test();
    }
}
#endif
