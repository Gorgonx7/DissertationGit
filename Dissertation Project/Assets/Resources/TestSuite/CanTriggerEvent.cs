#if(UNITY_EDITOR)
using ACE.Event_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTriggerEvent : TestCase
{
    // Start is called before the first frame update
    GameObject floor;
    GameObject eventObject;
    float timeSinceStart = 0;
    bool first = true;
    void Start()
    {
        CaseName = this.GetType().ToString();
        eventObject = Resources.Load<GameObject>("BuildableObjects/Electric_kettle");
        eventObject = Instantiate(eventObject);
        eventObject.transform.position = new Vector3(0, .5f, 0);
        floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3();

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (Mathf.Floor(timeSinceStart) == 2 && first) {
            eventObject.GetComponent<MeshCollider>().convex = true;
            eventObject.AddComponent<Rigidbody>();
            GameObject water = eventObject.transform.Find("water").gameObject;
            water.SetActive(false);
            ACE_Interaction inter = water.GetComponent<ACE_Interaction>();
            ACE_Action act = eventObject.AddComponent<ACE_Action>();
            act.ConfigureAction("pour", eventObject, new Vector3(45, 0, 0), eventObject.GetComponentInChildren<Grabable>(), false, true, false, false, "", inter);
            act.setTrigger(false);
            act.enabled = false;
            act.enabled = true;
            first = false;
        }
        if (Mathf.Floor(timeSinceStart) % 5 == 0 && timeSinceStart > 2) {
            Test();
        }
    }

    public override void Test()
    {
        eventObject.transform.Rotate(new Vector3(50, 0, 0));
        GameObject water = eventObject.transform.Find("water").gameObject;
        if (!water.activeInHierarchy)
        {
            failed = true;
        }
        DestroyImmediate(eventObject);
        DestroyImmediate(floor);



        base.Test();
    }
}
#endif
