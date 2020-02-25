using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 LockVector;
    public Vector3 MaxMovement;
    public bool AbsouluteMovement;
    public bool invert;
    private Vector3 startPosition;
    public Vector3 maxPosition, minPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        maxPosition = gameObject.transform.position + MaxMovement;
        if (!AbsouluteMovement)
        {
            minPosition = gameObject.transform.position - MaxMovement;
        }
        else
        {
            minPosition = startPosition;
        }
        if ((maxPosition.x < 0 && maxPosition.x < minPosition.x))
        {

       
        
            float holder = maxPosition.x;
            maxPosition.x = minPosition.x;
            minPosition.x = holder;
        }
        if(maxPosition.y < 0 && minPosition.y > minPosition.x)
        {
            float holder = maxPosition.y;
            maxPosition.y = minPosition.y;
            minPosition.y = holder;
        }
        if (maxPosition.z < 0 && maxPosition.z < minPosition.z)
        {
            float holder = maxPosition.z;
            maxPosition.z = minPosition.z;
            minPosition.z = holder;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    // adds a position together to give a new position
    public void Move(Vector3 position)
    {
        Vector3 holder = Vector3.Scale(position, LockVector);
        Constrain(ref holder);
        gameObject.transform.position += holder;
    }
    //applies a force to the object to move it
    public void ApplyForce(Vector3 force)
    {

    }
    //sets the position of the object
    public void MoveTo(Vector3 moveToPosition)
    {
        if(moveToPosition.x >= maxPosition.x)
            if(moveToPosition.x >= minPosition.x)
        {
            // this is the bit that is broken, we want to move even if the lock vector is 0, if it is 0 we need to just not set this was designed for move and needs to be changed for move to.
            Vector3 holder = applyLockVector(moveToPosition);

            gameObject.transform.position = holder;


        }
        
    }
    private Vector3 applyLockVector(Vector3 correctionVector)
    {
        Vector3 output = correctionVector;
        if(LockVector.x == 0)
        {
            output.x = gameObject.transform.position.x; 
        }
        if(LockVector.y == 0)
        {
            output.y = gameObject.transform.position.y;
        }
        if(LockVector.z == 0)
        {
            output.z = gameObject.transform.position.z;
        }
        return output;
    }
    //applies a force that will return the object to the start position
    private void Return()
    {

    }
    // limits the movement of the object
    private void Constrain(ref Vector3 PositionToMoveTo)
    {
        if (!invert)
        {
            if (PositionToMoveTo.x > maxPosition.x && LockVector.x  == 1)
            {
                PositionToMoveTo.x = maxPosition.x;
            }
            else if (PositionToMoveTo.x < minPosition.x)
            {
                PositionToMoveTo.x = minPosition.x;
            }
            if (PositionToMoveTo.y > maxPosition.y)
            {
                PositionToMoveTo.y = maxPosition.y;
            }
            else if (PositionToMoveTo.y < minPosition.y)
            {
                PositionToMoveTo.y = minPosition.y;
            }
            if (PositionToMoveTo.z > maxPosition.z)
            {
                PositionToMoveTo.z = maxPosition.z;
            }
            else if (PositionToMoveTo.z < minPosition.z)
            {
                PositionToMoveTo.z = minPosition.z;
            }
        }
        else
        {
            if (PositionToMoveTo.x < maxPosition.x)
            {
                PositionToMoveTo.x = maxPosition.x;
            }
            else if (PositionToMoveTo.x > minPosition.x)
            {
                PositionToMoveTo.x = minPosition.x;
            }
            if (PositionToMoveTo.y < maxPosition.y)
            {
                PositionToMoveTo.y = maxPosition.y;
            }
            else if (PositionToMoveTo.y > minPosition.y)
            {
                PositionToMoveTo.y = minPosition.y;
            }
            if (PositionToMoveTo.z < maxPosition.z)
            {
                PositionToMoveTo.z = maxPosition.z;
            }
            else if (PositionToMoveTo.z > minPosition.z)
            {
                PositionToMoveTo.z = minPosition.z;
            }
        }
    }
}
