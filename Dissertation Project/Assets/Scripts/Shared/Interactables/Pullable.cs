using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class Pullable : MonoBehaviour
{
    private Vector3 initialHandPosition;
   // private GameObject PullingHand;
    public float PullLimit = 5;
    public bool isBeingPulled = false;
    private Rigidbody m_rigidbody;
    public Vector3 InitialHandPosition;
    public bool lockX, lockY, lockZ;
    public Mover Optional_Mover;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pulled(GameObject otherHand)
    {
        InitialHandPosition = otherHand.transform.position;
        isBeingPulled = true;
        Debug.Log("PullGrabbed");
    }
    public void Released()
    {
        isBeingPulled = false;
        Debug.Log("released");
    }

    public void Pull(GameObject Hand)
    {
        if (Optional_Mover == null)
        {


            Debug.Log("beingPulled");
            Vector3 handMovement = Hand.transform.position - InitialHandPosition;

            if (!lockX && handMovement.x < PullLimit)
            {
                gameObject.transform.position = new Vector3(Hand.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (!lockY & handMovement.y < PullLimit)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Hand.transform.position.y, gameObject.transform.position.z);
            }
            if (!lockZ && handMovement.z < PullLimit)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Hand.transform.position.z);
            }
        }
        else
        {
            Optional_Mover.MoveTo(Hand.transform.position);
        }
    }
}
