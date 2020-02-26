using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private GameObject SelectedObject = null;
    private List<GameObject> PlacedObjects = new List<GameObject>();
    // Update is called once per frame
    
    void Update()
    {
        //TODO Fix this so that when an object is left clicked it can be placed but not if selecting a new object
       if(SelectedObject != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                SelectedObject.GetComponent<MouseFollowingBehaviour>().enabled = false;
                PlacedObjects.Add(SelectedObject);
                SelectedObject = null;
            }
        }
    }
    public void SelectGameObject(GameObject obj) {
        if (SelectedObject != null) {
            Destroy(SelectedObject);
        }
        SelectedObject = Instantiate(obj);
        SelectedObject.SetActive(true);
        SelectedObject.AddComponent<MouseFollowingBehaviour>();

    }
    public GameObject[] GetPlacedObjects()
    {
        return PlacedObjects.ToArray();
    }
}
