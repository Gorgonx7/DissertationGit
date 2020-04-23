using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Class responsible for managing the room builder
/// </summary>
public class BuildController : MonoBehaviour
{
    
    public GameObject SelectedObject = null;
    private List<GameObject> PlacedObjects = new List<GameObject>();
    public Slider ScaleSlider;

    /// Detect when a mouse button is pressed down and placing that object within the scene after    
    void Update()
    {
        if (enabled)
        {
            if (SelectedObject != null)
            {
                if (Input.GetMouseButtonDown(1))
                {

                    SelectedObject.GetComponent<MouseFollowingBehaviour>().enabled = false;
                    PlacedObjects.Add(SelectedObject);
                    SelectedObject = null;
                }
            }
        }
    }
    /// <summary>
    /// Called when a button is pressed to select an object
    /// </summary>
    /// <param name="obj"></param>
    public void SelectGameObject(GameObject obj) {
        if (SelectedObject != null) {
            Destroy(SelectedObject);
        }
        
        SelectedObject = Instantiate(obj);
        disableAllButMeshFilter(SelectedObject);
        for(int i = 0; i < SelectedObject.transform.childCount; i++)
        {
            disableAllButMeshFilter(SelectedObject.transform.GetChild(i).gameObject);
        }
        Collider holder = SelectedObject.GetComponent<Collider>();
        if(holder == null)
        {
            SelectedObject.AddComponent<MeshCollider>();
        }

        SelectedObject.transform.position = new Vector3(0, 0, 0);
        SelectedObject.SetActive(true);
        SelectedObject.AddComponent<MouseFollowingBehaviour>();
        SelectedObject.tag = "Selectable";
    }
    /// <summary>
    /// The following functions are all used to select and deselect objects after they are initially placed
    /// </summary>
    /// <param name="obj"></param>
    public void Select(GameObject obj)
    {
        enabled = false;
        SelectedObject = obj;
    }
    public void SelectAndMove(GameObject obj)
    {
        Select(obj);
        SelectedObject.GetComponent<MouseFollowingBehaviour>().enabled = true;
    }
    public void DeselectAndMove(GameObject obj)
    {
        if(SelectedObject != null)
        {
            SelectedObject.GetComponent<MouseFollowingBehaviour>().enabled = false;
        }
        Deselect(obj);
    }
    public void Deselect(GameObject obj)
    {
        enabled = true;
        SelectedObject = null;
    }
    /// <summary>
    /// Used to scale the selected object based off the input on a slider
    /// </summary>
    public void ScaleSelected()
    {
        if(SelectedObject != null)
        {
            SelectedObject.transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
            SelectedObject.transform.position = (new Vector3(SelectedObject.transform.position.x, 10, SelectedObject.transform.position.z));
            RaycastHit hit;
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            Vector3 predictedPosition = SelectedObject.transform.position;
            if (Physics.Raycast(SelectedObject.transform.position, -Vector3.up, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 hitPoint = hit.point;
                Vector3 bottomPoint = SelectedObject.GetComponent<Collider>().bounds.ClosestPoint(hitPoint);
                //Calculate the distance from the middle to the bottom of the object
                float distance = Vector3.Distance(bottomPoint, hitPoint);
                //Calculate the y position;
                predictedPosition.y = predictedPosition.y - distance;

            }
            SelectedObject.transform.position = predictedPosition;
        }
    }
    /// <summary>
    /// Returns all the placed objects within the room, returns them to the room saver
    /// </summary>
    /// <returns></returns>
    public GameObject[] GetPlacedObjects()
    {
        return PlacedObjects.ToArray();
    }
    /// <summary>
    /// Disables all the components on an object except the mesh and mesh filter as this is what is required for rendering the object.
    /// </summary>
    /// <param name="obj"></param>
    private void disableAllButMeshFilter(GameObject obj)
    {
        MonoBehaviour[] objectComps = obj.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour i in objectComps)
        {
            i.enabled = false;
        }
        if(SelectedObject.GetComponent<MeshRenderer>() != null)
        {
            SelectedObject.GetComponent<MeshRenderer>().enabled = true;

        }

    }
}
