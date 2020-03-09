using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
