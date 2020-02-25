using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject GetCollisionBox()
    {
        BoxCollider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;

        return gameObject;
    }
}
