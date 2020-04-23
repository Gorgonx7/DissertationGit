using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.Groups
{
    /// <summary>
    /// At start up the group distributer assigns a group to every key object within the scene
    /// </summary>
    public class GroupDistributor : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject[] keyObjects = GameObject.FindGameObjectsWithTag("KeyItem");
            foreach(GameObject i in keyObjects)
            {
                i.AddComponent<GroupItem>();
            }
        }
    }
}