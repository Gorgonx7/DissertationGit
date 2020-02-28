using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.Groups
{
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