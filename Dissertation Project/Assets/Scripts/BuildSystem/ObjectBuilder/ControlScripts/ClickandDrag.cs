using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to control the gimbol for the object build mode, this is resonsible for scaling the grab and interaction boxes
/// </summary>
public class ClickandDrag : MonoBehaviour
{
    public GameObject ObjectToAdjust;
    private bool MouseDown = false;
    public bool x, y, z;
    Vector2 previousMousePosition;
    public float sizingFactor = 0.1f;
    public bool negative = false;
    cameraRotate cameraRef;
    // Start is called before the first frame update
    void Start()
    {
        cameraRef = Camera.main.gameObject.GetComponent<cameraRotate>();
        if (gameObject.name == "Top")
        {
            y = true;
            
        }
        else if (gameObject.name == "Bottom")
        {
            y = true;
            negative = true;
        } else if(gameObject.name == "Left")
        {
            x= true;
            negative = true;
        } else if(gameObject.name == "Right")
        {
            x = true;

        } else if(gameObject.name == "Front")
        {
            z = true;
            negative = true;
        } else if(gameObject.name == "Back")
        {
            z = true;
        }
    }

    // Update is called once per frame
   
    private void OnMouseDown()
    {
        if (!this.enabled)
            return;
        // mouse has been clicked on object
        MouseDown = true;
        previousMousePosition = Input.mousePosition;
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
            Vector2 mousePosition = Input.mousePosition;
            float sign = 1.0f;
            if (negative)
            {
                sign = -1.0f;
            }
         
                Vector3 scale = ObjectToAdjust.transform.localScale;
               
                if (x) {
                    if (!cameraRef.IsRotated())
                    {
                        float scaleValue = ((mousePosition.x - previousMousePosition.x) * sizingFactor) * sign;
                        scale.x = scale.x + scaleValue;
                    }
                } else if (y) {
                    float scaleValue = ((mousePosition.y - previousMousePosition.y) * sizingFactor) * sign;
                    scale.y = scale.y + scaleValue;
                } else if (z) {
                    if (cameraRef.IsRotated())
                    {
                        float scaleValue = (mousePosition.x - previousMousePosition.x) * sizingFactor;
                        scale.z = scale.z + scaleValue;
                    }
                }
                ObjectToAdjust.transform.localScale = scale;

                


            previousMousePosition = mousePosition;
        }
    }
}
