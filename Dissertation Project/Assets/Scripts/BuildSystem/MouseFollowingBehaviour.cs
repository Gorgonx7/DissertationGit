using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Make an object follow the mouse, also stops following when tabbed out (think a multiuse computer)
public class MouseFollowingBehaviour : MonoBehaviour
{
    BuildController control;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("BuildController").GetComponent<BuildController>();
    }
    // Update is called once per frame
    void Update()
    {
       
        Vector3 mouseVector = Input.mousePosition;
        mouseVector.z += 10.0f;
       if(!(mouseVector.x == 0.0f || mouseVector.y == 0 ||  mouseVector.x >= Screen.width - 1 || mouseVector.y >= Screen.height - 1))
       {
            
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(mouseVector);
       }
      
    }
    
}
