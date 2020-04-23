using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    // returns the collison box associated with the grab box for the object builder
    public GameObject GetCollisionBox()
    {
        BoxCollider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;

        return gameObject;
    }
}
