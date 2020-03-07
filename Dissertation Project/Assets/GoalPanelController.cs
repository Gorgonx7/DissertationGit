using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACE.Goals;
using UnityEngine.UI;

public class GoalPanelController : MonoBehaviour
{

    public GameObject GoalUIPrefab;
    public GameObject InitialGoalUI;
    public GameObject parentObject;
    public float Offset = 3;
    public float XOffset = -244.33f;
    List<GameObject> GoalUIDefinitions = new List<GameObject>();
    private void Start()
    {
        GoalUIDefinitions.Add(InitialGoalUI);
    }
    public void CreateNewGoalUI()
    {
        GameObject holder = Instantiate(GoalUIPrefab);
        
        holder.transform.SetParent(parentObject.transform);

        holder.transform.localPosition = new Vector3(XOffset, GoalUIDefinitions.Count * Offset, 0);
        GoalUIDefinitions.Add(holder);
    }

    public GoalSaveStruct[] GetGoalsToSave()
    {
        GoalSaveStruct[] output = new GoalSaveStruct[GoalUIDefinitions.Count];
        for (int i = 0; i < GoalUIDefinitions.Count; i++)
        {
            string goalName = "";
            string itemName = "";
            string[] associatedItemNames = new string[0];
            InputField[] inputFields = GoalUIDefinitions[i].GetComponentsInChildren<InputField>();
            foreach (InputField j in inputFields)
            {
                if (j.text.Trim() == "")
                {
                    continue;
                }
                switch (j.gameObject.transform.parent.gameObject.name)
                {

                    case "GoalNameTitle":
                        goalName = j.text;
                        break;
                    case "Goal Item Name":
                        itemName = j.text;
                        break;
                    case "items needed to complete goal":
                        associatedItemNames = j.text.Split('/');
                        break;
                }
            }

            if (goalName.Trim() == "" || itemName.Trim() == "" || associatedItemNames.Length == 0)
            {
                continue;
            }
            output[i] = new GoalSaveStruct(goalName, itemName, associatedItemNames);
        }
        return output;
    }
}
