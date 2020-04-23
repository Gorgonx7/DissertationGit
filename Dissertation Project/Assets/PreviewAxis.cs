using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// controlls the previews of the rotation settings defined by the user for events
/// </summary>
public class PreviewAxis : MonoBehaviour
{
    public void TryToggleX()
    {
        GameObject editObject = GameObject.FindGameObjectWithTag("EditableObject");
        if (editObject != null)
        {
            editObject.GetComponent<RotationPreview>().ToggleX();
        }
    }
    public void TryToggleY()
    {
        GameObject editObject = GameObject.FindGameObjectWithTag("EditableObject");
        if (editObject != null)
        {
            editObject.GetComponent<RotationPreview>().ToggleY();
        }
    }
    public void TryToggleZ()
    {
        GameObject editObject = GameObject.FindGameObjectWithTag("EditableObject");
        if (editObject != null)
        {
            editObject.GetComponent<RotationPreview>().ToggleZ();
        }
    }
    public void TryToggleRotation()
    {
        GameObject editObject = GameObject.FindGameObjectWithTag("EditableObject");
        if (editObject != null)
        {
            editObject.GetComponent<RotationPreview>().ToggleRotation();
        }
    }
    public void TryChangeLimit()
    {
        GameObject editObject = GameObject.FindGameObjectWithTag("EditableObject");
        if (editObject != null)
        {
            editObject.GetComponent<RotationPreview>().UpdateConstraint();
        }
    }

}
