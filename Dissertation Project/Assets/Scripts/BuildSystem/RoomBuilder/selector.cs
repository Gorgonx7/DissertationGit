using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that controls selecting objects again within the room builder
/// </summary>
public class selector : MonoBehaviour
{
    public Material SelectionMaterial;
    public GameObject SelectedObject;
    public BuildController control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Fancy raycast collision detector to find out which object is selected and display a glowing object around it
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit))
            {
                if (SelectedObject != null && hit.collider.gameObject.tag == "Selectable")
                {
                    control.Deselect(SelectedObject);
                    Destroy(SelectedObject.transform.Find("GlowHolder" + SelectedObject.name).gameObject);
                    SelectedObject = null;
                }
                else
                {
                    if (hit.collider.gameObject.tag == "Selectable")
                    {
                        SelectedObject = hit.collider.gameObject;
                        GameObject glowHolder = new GameObject("GlowHolder" + SelectedObject.name);
                        glowHolder.transform.SetParent(SelectedObject.transform, false);
                        glowHolder.layer = 10;
                        glowHolder.transform.Translate(new Vector3(0, -0.02f, 0));
                        glowHolder.AddComponent<MeshFilter>();
                        glowHolder.AddComponent<MeshRenderer>();
                        glowHolder.GetComponent<MeshFilter>().mesh = SelectedObject.GetComponent<MeshFilter>().mesh;
                        glowHolder.GetComponent<MeshRenderer>().material = SelectionMaterial;
                        control.Select(SelectedObject);
                    }
                }
            } 
        }else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (SelectedObject != null)
                {
                    control.DeselectAndMove(SelectedObject);
                    Destroy(SelectedObject.transform.Find("GlowHolder" + SelectedObject.name).gameObject);
                    SelectedObject = null;
                }
                else
                {
                    if (hit.collider.gameObject.tag == "Selectable")
                    {
                        SelectedObject = hit.collider.gameObject;
                        GameObject glowHolder = new GameObject("GlowHolder" + SelectedObject.name);
                        glowHolder.transform.SetParent(SelectedObject.transform, false);
                        glowHolder.layer = 10;
                        glowHolder.transform.Translate(new Vector3(0, -0.02f, 0));
                        glowHolder.AddComponent<MeshFilter>();
                        glowHolder.AddComponent<MeshRenderer>();
                        glowHolder.GetComponent<MeshFilter>().mesh = SelectedObject.GetComponent<MeshFilter>().mesh;
                        glowHolder.GetComponent<MeshRenderer>().material = SelectionMaterial;
                        control.SelectAndMove(SelectedObject);
                    }
                }
            }
        }
    }
}

