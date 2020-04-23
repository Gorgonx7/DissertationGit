using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used in the object build to translate the grab and interaction boxes
/// </summary>
public class ClickandDragTranslate : MonoBehaviour
{
    bool MouseDown = false;
    public bool x, y, z = false;
    public GameObject translationTarget;
    cameraRotate CameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        CameraRotation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraRotate>();
        if (gameObject.name == "Top")
        {
            y = true;

        }
        else if (gameObject.name == "Bottom")
        {
            y = true;
           
        }
        else if (gameObject.name == "Left")
        {
            x = true;
            
        }
        else if (gameObject.name == "Right")
        {
            x = true;

        }
        else if (gameObject.name == "Front")
        {
            z = true;
            
        }
        else if (gameObject.name == "Back")
        {
            z = true;
        }
    }

   
    private void OnMouseDown()
    {
        if (!this.enabled)
            return;
        // mouse has been clicked on object
        MouseDown = true;
        
    }
    private void OnMouseUp()
    {
        if (!this.enabled)
            return;
        MouseDown = false;

    }
    private void OnMouseDrag()
    {
        if (!this.enabled)
            return;
        if (MouseDown)
        {
            if (x && !CameraRotation.IsRotated())
            {
                translationTarget.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, translationTarget.transform.position.y, translationTarget.transform.position.z);
            } else if (y)
            {
                translationTarget.transform.position = new Vector3(translationTarget.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, translationTarget.transform.position.z);

            }
            else if (z && CameraRotation.IsRotated())
            {
                translationTarget.transform.position = new Vector3(translationTarget.transform.position.x, translationTarget.transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);

            }
        }
    }
}
