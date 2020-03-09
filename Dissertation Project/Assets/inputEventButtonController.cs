using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACE.Goals;
using UnityEngine.UI;

public class inputEventButtonController : MonoBehaviour
{

    public GameObject UIPrefab;
    public GameObject InitialUI;
    public GameObject parentObject;
    public float Offset = 0;
    public float XOffset = 0;
    List<GameObject> UIDefinitions = new List<GameObject>();
    private void Start()
    {
        UIDefinitions.Add(InitialUI);
    }
    public void CreateNewUI()
    {
        GameObject holder = Instantiate(UIPrefab);
        
        holder.transform.SetParent(InitialUI.transform, false);
        holder.transform.SetParent(InitialUI.transform.parent);
        holder.transform.localPosition = new Vector3(XOffset, holder.transform.localPosition.y - ((UIDefinitions.Count + 3) * Offset) , holder.transform.localPosition.z);
        UIDefinitions.Add(holder);
    }
    public List<GameObject> GetUIDefinitions()
    {
        return UIDefinitions;
    }
   
        
}
