using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField]
    GameObject[] BuildableObjects;
    // Start is called before the first frame update
    GameObject[] ButtonArray;
    public GameObject buttonPrefab;
    void Start()
    {
        
        BuildableObjects = Resources.LoadAll<GameObject>("BuildableObjects");
        ButtonArray = new GameObject[BuildableObjects.Length];
        for(int x = 0; x < ButtonArray.Length; x++)
        {
            ButtonArray[x] = Instantiate(buttonPrefab);
            ButtonArray[x].transform.parent = gameObject.transform;
            ButtonArray[x].GetComponent<attatchBuildObject>().setBuildObject(BuildableObjects[x]);
            ButtonArray[x].GetComponentInChildren<Text>().text = BuildableObjects[x].name;
            
            ButtonArray[x].GetComponent<RectTransform>().anchoredPosition = new Vector3((-GetComponent<RectTransform>().rect.width / 2 ) + ButtonArray[x].GetComponent<RectTransform>().rect.width, (GetComponent<RectTransform>().rect.height / 2) - ButtonArray[x].GetComponent<RectTransform>().rect.height, 0); 
            ButtonArray[x].transform.position += new Vector3(0,-(ButtonArray[x].GetComponent<RectTransform>().rect.height * x),0);


        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
