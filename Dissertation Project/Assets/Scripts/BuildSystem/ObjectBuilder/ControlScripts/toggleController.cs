using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the toggles for scaling and translating the grab boxes
/// </summary>
public class toggleController : MonoBehaviour
{
    
    public List<ClickandDragTranslate> BehaviourToDeactivate = new List<ClickandDragTranslate>();
    public List<ClickandDrag> BehaviourToActivate = new List<ClickandDrag>();
    public void StateChange()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            foreach(MonoBehaviour i in BehaviourToDeactivate)
            {
                i.enabled = false;
            }
            foreach(MonoBehaviour i in BehaviourToActivate)
            {
                i.enabled = true;
            }
        } else
        {
            foreach (MonoBehaviour i in BehaviourToDeactivate)
            {
                i.enabled = true;
            }
            foreach (MonoBehaviour i in BehaviourToActivate)
            {
                i.enabled = false;
            }
        }
    }
}
