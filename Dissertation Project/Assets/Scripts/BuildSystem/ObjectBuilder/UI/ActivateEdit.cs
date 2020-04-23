using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to control the toggles in the UI, turns on and off objects in the object builder when a toggle is turned on
/// </summary>
public class ActivateEdit : MonoBehaviour
{
    public List<GameObject> activations = new List<GameObject>();

    public void StateChange()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            foreach (GameObject i in activations)
            {
                i.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject i in activations)
            {
                i.SetActive(false);
            }
        }
    }
}
