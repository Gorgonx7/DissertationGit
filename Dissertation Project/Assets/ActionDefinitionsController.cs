using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ACE.Event_System;
public class ActionDefinitionsController : MonoBehaviour
{
    enum ActionType
    {
        Rotation, Combine
    }
   public void ApplyActionDefinitions(GameObject objecToAddValuesTo, Grabable GrabBox)
    {
        List<GameObject> ActionSettings = GetComponent<inputEventButtonController>().GetUIDefinitions();
        //Now we have a list of action UI definitions, we now configure the object to have 
        //Structure of prefab:
        //TopLevelPane
        //     --> Dropdown
        //     --> text
        //          --> InputField
        //     --> text
        //          --> InputField
        foreach(GameObject i in ActionSettings)
        {
            string EventName = i.transform.Find("EventName").gameObject.GetComponent<InputField>().text;
            
            switch ((ActionType)i.GetComponentInChildren<Dropdown>().value)
            {
                case ActionType.Rotation:
                    GameObject rotatePanel = i.transform.Find("RotatePanel").gameObject;
                    bool x = false, y = false , z = false;
                    int rotatePercent = int.Parse(rotatePanel.transform.Find("RotatePercentName").GetChild(0).gameObject.GetComponent<InputField>().text);
                    Vector3 transformVector = new Vector3();
                    if (rotatePanel.transform.Find("xToggle").GetComponent<Toggle>().isOn)
                    {
                        transformVector.x = rotatePercent;
                        x = true;

                    } else if (rotatePanel.transform.Find("yToggle").GetComponent<Toggle>().isOn)
                    {
                        transformVector.y = rotatePercent;
                        x = true;
                    }
                    else
                    {
                        transformVector.z = rotatePercent;
                        x = true;
                    }
                    string requiredName = i.transform.Find("RequiredName").GetComponent<InputField>().text;
                    if(requiredName == ""){
                        requiredName = null; 
                    }
                    ACE_Action holder = objecToAddValuesTo.AddComponent<ACE_Action>();
                    holder.ConfigureAction(EventName, objecToAddValuesTo, transformVector, GrabBox, rotatePanel.transform.Find("Inverted").GetComponent<Toggle>().isOn, x, y, z, requiredName);
                    
                    break;
                case ActionType.Combine:
                    break;
            }
        }

    }
}
