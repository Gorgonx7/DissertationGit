#if(UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSightSystemSee : TestCase
{
    GameObject sightCube;
    bool first = true;
    bool second, third = false;
    bool complete = false;
    float timeSinceStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        CaseName = this.GetType().ToString();
        Camera.main.transform.position = new Vector3(0, 0, -10);
        sightCube = Resources.Load<GameObject>("TestSuite/sightTestCube");
        sightCube = Instantiate(sightCube);
        sightCube.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > 10)
        {
            if (Mathf.Floor(timeSinceStart) % 5 == 0)
            {
                Test();
            }
        }
    }
    public override void Test()
    {
        
        if(first)
        {
            if (sightCube.GetComponent<SeenBehaviour>().GetTimeInFocus() > 0)
            {
                sightCube.transform.position = new Vector3(3, 0, 0);
                first = false;
                second = true;
                timeSinceStart += 1;
            } else
            {
                failed = true;
                first = false;
                complete = true;
                DestroyImmediate(sightCube);
            }
        }
        else if(second && !failed)
        {
            if(sightCube.GetComponent<SeenBehaviour>().GetTimeInPeriferal() > 0)
            {
                DestroyImmediate(sightCube);
                complete = true;
            }
        }
        if (complete) {
            
            base.Test();
        }
    }
}
#endif
