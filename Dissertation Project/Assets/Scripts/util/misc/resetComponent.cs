﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// resets an object  to its original position
/// </summary>
public class resetComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "KeyItem")
        {
            GameObject worldAnchor = GameObject.Find(collision.gameObject.name + "WorldAnchor");
            collision.gameObject.transform.position = worldAnchor.transform.position;
            collision.gameObject.transform.rotation = worldAnchor.transform.rotation;

        }
    }
}
