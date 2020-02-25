using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    public Transform RotationPoint;
    public bool isRotated = false;
    public void RotateCameraRight()
    {
        gameObject.transform.RotateAround(RotationPoint.position,Vector3.up, 90);
        if (!isRotated)
        {
            isRotated = true;
        } else 
        {
            isRotated = false;
        }
    }
    public void RotateCameraLeft()
    {
        gameObject.transform.RotateAround(RotationPoint.position, Vector3.up, -90);
        if (!isRotated)
        {
            isRotated = true;
        }
        else
        {
            isRotated = false;
        }
    }
    public bool IsRotated()
    {
        return isRotated;
    }
}
