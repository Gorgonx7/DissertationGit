using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attatchBuildObject : MonoBehaviour
{
    
    private GameObject BuildObjectPrefab;
    private BuildController BuildController;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { setSelectedObject(); });
        BuildController = GameObject.FindGameObjectWithTag("BuildController").GetComponent<BuildController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setSelectedObject()
    {
        BuildController.SelectGameObject(BuildObjectPrefab);
    }
    public void setBuildObject(GameObject inObject)
    {
        BuildObjectPrefab = inObject;
    }
}
