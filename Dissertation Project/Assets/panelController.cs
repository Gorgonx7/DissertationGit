using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the rotate and combine pannels switching between the two settings
/// </summary>
public class panelController : MonoBehaviour
{
    public GameObject RotatePannel;
    public GameObject CombinePannel;
   public void ShowUIpannel()
    {
        RotatePannel.SetActive(false);
        CombinePannel.SetActive(false);
        switch (GetComponent<Dropdown>().value)
        {
            case 0:
                RotatePannel.SetActive(true);
                break;
            case 1:
                CombinePannel.SetActive(true);
                break;
        }
    }
}
