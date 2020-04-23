using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    /// <summary>
    /// Changes the scale of the room in the room builder
    /// </summary>
    public void ChangeScale()
    {
        float value = gameObject.GetComponent<Slider>().value;
        GameObject.FindGameObjectWithTag("Floor").transform.localScale = new Vector3(value, value, value);
    }
}
