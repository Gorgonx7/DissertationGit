using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesPlayerExist : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(playerPrefab);
        }
    }
   
  
}
