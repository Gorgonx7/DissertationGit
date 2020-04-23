using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// sets the height of the user based off of the global variabels
/// </summary>
public class setHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float playerHeight = GlobalVariables.HeadsetHeight;
        float designedHeight = 1.8f;
        float difference = designedHeight - playerHeight;
        gameObject.transform.Translate(new Vector3(0, difference, 0));
        Destroy(this);
    }

  
}
