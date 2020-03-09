using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowToImproveController : MonoBehaviour
{

    public void UpdateWaysToImprove(string[] improvementStrings)
    {
        int numberOfImprovements = 0;
        if(improvementStrings.Length <= 5)
        {
            numberOfImprovements = improvementStrings.Length;
        }
        else
        {
            numberOfImprovements = 5;
        }
        Text textComp = GetComponent<Text>();
        string output = "";
        for(int x = 0; x < numberOfImprovements; x++)
        {
            output += "> " + improvementStrings[x] + "\n";
        }
        textComp.text = output;
    }
}
