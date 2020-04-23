using ACE.FileSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to create the UI buttons for the room builder
/// </summary>
public class ButtonCreator : MonoBehaviour
{
  
    GameObject[] BuildableObjects;
  
    GameObject[] ButtonArray;
    public GameObject parentObject;
    public GameObject buttonPrefab;
    void Start()
    {
        GameObjectCaretaker gameObjectCaretaker = new GameObjectCaretaker();
        GameObject[] UDOObjects = gameObjectCaretaker.LoadAllObjects();
        foreach (GameObject i in UDOObjects)
        {
            if(i.GetComponent<Rigidbody>() != null)
            {
                i.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                if(i.GetComponent<Collider>() == null)
                {
                    i.AddComponent<MeshCollider>();
                }
            }
            i.SetActive(false);
        }
        BuildableObjects = Resources.LoadAll<GameObject>("BuildableObjects");
        GameObject[] CombinedArray = new GameObject[BuildableObjects.Length + UDOObjects.Length];
        BuildableObjects.CopyTo(CombinedArray, 0);
        UDOObjects.CopyTo(CombinedArray, BuildableObjects.Length);
        BuildableObjects = CombinedArray;
        ButtonArray = new GameObject[BuildableObjects.Length];
        for(int x = 0; x < ButtonArray.Length; x++)
        {
            ButtonArray[x] = Instantiate(buttonPrefab);
            ButtonArray[x].transform.SetParent(gameObject.transform);
            ButtonArray[x].GetComponent<attatchBuildObject>().setBuildObject(BuildableObjects[x]);
            ButtonArray[x].GetComponentInChildren<Text>().text = BuildableObjects[x].name;
            
            ButtonArray[x].GetComponent<RectTransform>().anchoredPosition = new Vector3((-GetComponent<RectTransform>().rect.width / 2 ) + ButtonArray[x].GetComponent<RectTransform>().rect.width, (GetComponent<RectTransform>().rect.height / 2) - ButtonArray[x].GetComponent<RectTransform>().rect.height, 0); 
            ButtonArray[x].transform.position += new Vector3(0,-(ButtonArray[x].GetComponent<RectTransform>().rect.height * x),0);
            ButtonArray[x].transform.SetParent(parentObject.transform);
        }
        


    }
}
