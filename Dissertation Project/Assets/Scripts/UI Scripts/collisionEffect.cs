using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionEffect : MonoBehaviour {

    private Vector3 initialScale;
    // Use this for initialization
	void Start () {
        initialScale = gameObject.transform.localScale;
	}
    [SerializeField]
    private float scaleIncrease = 0.0f;
    private bool sizeUp = true;
    public float step = 0.0001f;
    public float scaleLimit = 0.00005f;
	// Update is called once per frame
	void Update () {
        
       
    }
     void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (sizeUp)
        {
            scaleIncrease += step * Time.deltaTime;
            if (scaleIncrease >= scaleLimit)
            {
                sizeUp = false;
            }
            gameObject.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
        }
        else
        {
            scaleIncrease -= step * Time.deltaTime;
            if (scaleIncrease <= -scaleLimit)
            {
                sizeUp = true;
            }
            gameObject.transform.localScale -= new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.localScale = initialScale;
    }
  
}
