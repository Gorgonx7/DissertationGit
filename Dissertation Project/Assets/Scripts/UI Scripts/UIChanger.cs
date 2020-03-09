using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChanger : MonoBehaviour
{
    public GameObject UIToChangeTo;

    public List<GameObject> UIToDeactivate;
    
    public void activate() {
        UIToChangeTo.SetActive(true);

        foreach(GameObject i in UIToDeactivate)
        {
            i.SetActive(false);
        }
    }
   
}
