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
        mouseVector.z += 10;
        Vector3 predictedPosition = Camera.main.ScreenToWorldPoint(mouseVector);
        //predictedPosition.y += 10;
      //  predictedPosition.z += 10;
        //  if(!(mouseVector.x == 0.0f || mouseVector.y == 0 ||  mouseVector.x >= Screen.width - 1 || mouseVector.y >= Screen.height - 1))
        //{
        gameObject.transform.position = predictedPosition;

        // }
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
       if(Physics.Raycast(gameObject.transform.position, -Vector3.up, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 hitPoint = hit.point;
            Vector3 bottomPoint = GetComponent<Collider>().bounds.ClosestPoint(hitPoint);
            //Calculate the distance from the middle to the bottom of the object
            float distance = Vector3.Distance(bottomPoint, hitPoint);
            //Calculate the y position;
            predictedPosition.y = predictedPosition.y - distance;

        }
        gameObject.transform.position = predictedPosition;

    }
    
}
