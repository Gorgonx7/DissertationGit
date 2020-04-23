using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// used a control script for the UI to trun on the grab box and grab box edit button
/// </summary>
public class CreateGrabUI : MonoBehaviour
{
    public GameObject GrabButton;
    public GameObject GrabBox;
    
    public void ToggleGrabButton()
    {

       
        if (!GrabButton.activeSelf)
        {
            GrabButton.SetActive(true);
            GrabBox.SetActive(true);
        }
        else
        {
            GrabButton.SetActive(false);
            GrabBox.SetActive(false);
        }
    }
}
