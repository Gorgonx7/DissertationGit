using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject i in GlobalVariables.UDOsForScene)
        {
            Instantiate(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
