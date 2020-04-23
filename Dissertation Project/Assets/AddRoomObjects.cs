using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// instantiates all the objects for a scene when loaded
/// </summary>
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

    
}

