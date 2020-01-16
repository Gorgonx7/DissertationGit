using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeenBehaviour : MonoBehaviour
{
    public Color SeenColour = Color.green;
    public Color inView = Color.yellow;
    public Color notSeen = Color.red;
    public Material FadeMaterial;
    public float nearFloat = 0.3f;

 
    float lastSeentime;
    float totalTimeSpentInFrame;

    bool isSeen = false;
    private void Start()
    {
        
        lastSeentime = Time.time;
        totalTimeSpentInFrame = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        float isInFront = gameObject.transform.position.z * Camera.main.transform.position.z;
        
        if(ScreenPosition.x >= 0.0f && ScreenPosition.x <= 1.0f && ScreenPosition.y >= 0 && ScreenPosition.y <= 1.0f && ScreenPosition.z >= Camera.main.nearClipPlane && ScreenPosition.z <= Camera.main.farClipPlane) {
           if(ScreenPosition.x < nearFloat || ScreenPosition.y < nearFloat || ScreenPosition.x > 1 - nearFloat || ScreenPosition.y > 1- nearFloat)
            {
                FadeMaterial.color = inView;
            }
            else
            {
                FadeMaterial.color = SeenColour;
                
            }
            isSeen = true;
            totalTimeSpentInFrame += Time.deltaTime;
            lastSeentime = Time.time;
            
        }
        else
        {
            FadeMaterial.color = notSeen;
            isSeen = false;
        }

    }

    public bool Seen()
    {
        return isSeen;
    }
    public float Central()
    {
        Vector3 ScreenPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        float isInFront = gameObject.transform.position.z * Camera.main.transform.position.z;

        if (ScreenPosition.x >= 0.0f && ScreenPosition.x <= 1.0f && ScreenPosition.y >= 0 && ScreenPosition.y <= 1.0f && ScreenPosition.z >= Camera.main.nearClipPlane && ScreenPosition.z <= Camera.main.farClipPlane)
        {
            return 1.0f - ((ScreenPosition.x + ScreenPosition.y) / 2.0f); 
        }
            return 0.0f;
    }
}
