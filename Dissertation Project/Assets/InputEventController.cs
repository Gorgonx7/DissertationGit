using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ACE.Event_System;
/// <summary>
/// saves the input events to a given gameobject
/// </summary>
public class InputEventController : MonoBehaviour
{
    public inputEventButtonController control;
   public void ApplyInputEvents(GameObject objectToApplyto)
   {
        Dictionary<string, string> stateDict = new Dictionary<string, string>();
        foreach (GameObject i in control.GetUIDefinitions())
        {
            Transform root = i.transform;
            string inputEvent = root.Find("Input Event").GetComponent<InputField>().text;
            string stateChangeTo = root.Find("State Change").GetComponent<InputField>().text;
            stateDict.Add(inputEvent, stateChangeTo);
        }
        ACE_StateMachine stateMachine = objectToApplyto.AddComponent<ACE_StateMachine>();
        stateMachine.stateChanges = stateDict;
   }
}
