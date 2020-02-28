using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawControllerLine : MonoBehaviour {

    public float lineLength = 2.5f;
    public LineRenderer m_renderer;
    public float rotationFix = 0.0f;
    // Use this for initialization
	void Start () {
        //renderer.SetColors(Color.red, Color.white);
	}

    // Update is called once per frame
    private void Update()
    {
        //  Debug.Log(gameObject.transform.position.ToString());
        Quaternion currentRotation = gameObject.transform.rotation;
        currentRotation.z = 0;
        currentRotation.x += rotationFix;
        m_renderer.SetPosition(0,  gameObject.transform.position);
        Vector3 endVector = gameObject.transform.position + new Vector3(0, 0, lineLength);

        m_renderer.SetPosition(1,  currentRotation * endVector);
        
    }
}
