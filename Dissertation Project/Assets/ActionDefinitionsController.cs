using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ACE.Event_System;
/// <summary>
/// Used to save the action definitions within the object builder menu
/// </summary>
public class ActionDefinitionsController : MonoBehaviour
{
    public GameObject InteractableBox;
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
            InteractableBox.transform.DetachChildren();
            InteractableBox.name = objecToAddValuesTo.name + "Handle";
            InteractableBox.transform.parent = objecToAddValuesTo.transform;
            Destroy(InteractableBox.GetComponent<ColorPickerTester>());
            if (EventName == "")
            {
                continue;
            }
            switch ((ActionType)i.GetComponentInChildren<Dropdown>().value)
            {
                case ActionType.Rotation:
                   
                    
                    GameObject rotatePanel = i.transform.Find("RotatePanel").gameObject;
                    bool x = false, y = false , z = false;
                    bool inverse = rotatePanel.transform.Find("Inverted").GetComponent<Toggle>().isOn;
                    int rotatePercent = int.Parse(rotatePanel.transform.Find("RotatePercentName").GetChild(0).gameObject.GetComponent<InputField>().text);
                    Vector3 transformVector = new Vector3();
                    if (rotatePanel.transform.Find("xToggle").gameObject.GetComponent<Toggle>().isOn)
                    {
                        transformVector.x = rotatePercent;
                        x = true;

                    } else if (rotatePanel.transform.Find("yToggle").gameObject.GetComponent<Toggle>().isOn)
                    {
                        transformVector.y = rotatePercent;
                        y = true;
                    }
                    else
                    {
                        transformVector.z = rotatePercent;
                        z = true;
                    }
                    string requiredName = i.transform.Find("RequiredName").gameObject.GetComponent<InputField>().text;
                    if(requiredName == ""){
                        requiredName = null; 
                    }
                    ACE_Action holder = objecToAddValuesTo.AddComponent<ACE_Action>();
                    holder.ConfigureAction(EventName, objecToAddValuesTo, transformVector, GrabBox, rotatePanel.transform.Find("Inverted").GetComponent<Toggle>().isOn, x, y, z, requiredName, InteractableBox.AddComponent<ACE_Interaction>());
                    holder.setTrigger(inverse);
                    break;
                case ActionType.Combine:
                    GameObject combinePanel = i.transform.Find("CombinePanel").gameObject;
                    string input = combinePanel.transform.Find("OtherName").gameObject.GetComponent<InputField>().text;
                    string stateChange = combinePanel.transform.Find("StateToField").gameObject.GetComponent<InputField>().text;
                    bool changeName = combinePanel.transform.Find("StateToToggle").gameObject.GetComponent<Toggle>().isOn;
                    ACE_Combine hol = objecToAddValuesTo.AddComponent<ACE_Combine>();
                    hol.StateString = stateChange;
                    hol.combineName = EventName;
                    hol.ListOfCombineObjectsNames = new List<string>(input.Split(','));
                    break;
            }
        }

    }
}
