using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewScriptOption : MonoBehaviour
{
    public GameObject DropdownPrefab;
    public float yDisplacement = 10;
    public float xValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddAnotherButton()
    {
        GameObject belowProperty = Instantiate(DropdownPrefab);
        belowProperty.transform.SetParent(gameObject.transform.parent.gameObject.transform.parent, false);
        belowProperty.GetComponent<RectTransform>().localPosition += new Vector3(150, 0, 0);
        belowProperty.transform.localPosition = new Vector3(xValue, belowProperty.transform.localPosition.y + yDisplacement, belowProperty.transform.localPosition.z);
       // belowProperty.GetComponent<RectTransform>().localPosition += new Vector3(150, 0, 0);
        gameObject.SetActive(false);
    }
}
