using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Previous the rotation in the object builder
/// </summary>
public class RotationPreview : MonoBehaviour
{
    bool isRotating = false;

    bool x, y, z = false;
    public float rotationAmount = 100f;
    public float constraint = 180;
    public Text constraintBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            gameObject.transform.Rotate(x? rotationAmount *Time.deltaTime : 0, y? rotationAmount *Time.deltaTime : 0, z? rotationAmount *Time.deltaTime : 0);
            Vector3 Rotation = gameObject.transform.rotation.eulerAngles;

            if (rotationAmount < 0)
            {
                if ((Rotation.x < (360 - constraint) && Rotation.x != 0) | (Rotation.y < (360 - constraint) && Rotation.y != 0) | (Rotation.z < (360 - constraint) && Rotation.z != 0))
                {
                    gameObject.transform.rotation = new Quaternion();
                }
            }
            else
            {
                if (Mathf.Abs(Rotation.x) > constraint | Mathf.Abs(Rotation.y) > constraint | Mathf.Abs(Rotation.z) > constraint)
                {
                    gameObject.transform.rotation = new Quaternion();
                }
            }
            
        }
    }

    public void ToggleRotation()
    {
        gameObject.transform.rotation = new Quaternion();
        isRotating = isRotating ? false : true;
    }
    public void ToggleX()
    {
        gameObject.transform.rotation = new Quaternion();
        x = x ? false : true;
    }
    public void ToggleY()
    {
        gameObject.transform.rotation = new Quaternion();
        y = y ? false : true;
    }
    public void ToggleZ()
    {
        gameObject.transform.rotation = new Quaternion();
        z = z ? false : true;
    }
    public void UpdateConstraint()
    {
        string pInput = constraintBox.text;
        float val = float.Parse(pInput);
        if(val > 180.0f)
        {
            val = 180.0f;
        }
        if(val < 0.0f)
        {
            val = 0.0f;
        }
        constraint = val == 0 ? 180 : val;
    }
    public void inverse()
    {
        rotationAmount *= -1;

    }
}
