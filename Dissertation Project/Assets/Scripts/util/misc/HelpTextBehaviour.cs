using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelpTextBehaviour : MonoBehaviour
{
    public string helpText;
    public GameObject helpTextPrefab;
    private GameObject helpTextInstance;
    // Start is called before the first frame update
    //TODO refactor
    void Start()
    {
        helpTextInstance = Instantiate(helpTextPrefab);
        helpTextInstance.GetComponent<RectTransform>().anchoredPosition += new Vector2(-2, 3);
        helpTextInstance.transform.parent = gameObject.transform;
        
        /*if(GetComponent<ObjectVariables>() != null)
        {
            helpTextInstance.GetComponentInChildren<Text>().text = GetComponent<ObjectVariables>().helpText;
        }
        else
        {
            helpTextInstance.GetComponentInChildren<Text>().text = gameObject.name;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SeenBehaviour>().Seen())
        {
            helpTextInstance.SetActive(true);
        }
        else
        {
            helpTextInstance.SetActive(false);
        }
    }
}
