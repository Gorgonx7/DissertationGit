using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrabUI : MonoBehaviour
{
    public GameObject GrabButton;
    public GameObject GrabBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleGrabButton()
    {

       
        if (!GrabButton.activeSelf)
        {
            GrabButton.SetActive(true);
            GrabBox.SetActive(true);
        }
        else
        {
            GrabButton.SetActive(false);
            GrabBox.SetActive(false);
        }
    }
}
