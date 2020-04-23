using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A simple class that attempts to understand how a user is seeing objects within the scene, registering the objects within their periferal and central vision
/// </summary>
public class SeenBehaviour : MonoBehaviour
{
    public Color SeenColour = Color.green;
    public Color inView = Color.yellow;
    public Color notSeen = Color.red;
    public Material FadeMaterial;
    public float nearFloat = 0.3f;
    GameObject glowHolder;
    Camera vrCamera;

    float lastSeentime = 0.0f;
    float totalTimeSpentInFrame = 0.0f;
    float totalTimeSpentInFocus = 0.0f;
    float totalTimeSpentInPeriferal = 0.0f;
    bool isSeen = false;
    private void Start()
    {
        
        lastSeentime = Time.time;
        totalTimeSpentInFrame = 0.0f;
        glowHolder = new GameObject("GlowHolder" + gameObject.name);
        glowHolder.transform.SetParent(gameObject.transform,false);
        glowHolder.layer = 10;
        glowHolder.transform.Translate(new Vector3(0, -0.02f, 0));
        glowHolder.AddComponent<MeshFilter>();
        glowHolder.AddComponent<MeshRenderer>();
        glowHolder.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
        glowHolder.GetComponent<MeshRenderer>().material = FadeMaterial;
        

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            vrCamera = GameObject.Find("VRCamera").GetComponent<Camera>();
        }
        catch
        {
            return;
        }
        Vector3 ScreenPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        float isInFront = gameObject.transform.position.z * Camera.main.transform.position.z;
        RaycastHit hit;
        Physics.Linecast(vrCamera.transform.position, gameObject.transform.position, out hit);
        if (hit.transform != null && hit.transform.gameObject.name == gameObject.name)
        {

            if (ScreenPosition.x >= 0.0f && ScreenPosition.x <= 1.0f && ScreenPosition.y >= 0 && ScreenPosition.y <= 1.0f && ScreenPosition.z >= Camera.main.nearClipPlane && ScreenPosition.z <= Camera.main.farClipPlane)
            {
                if (ScreenPosition.x < nearFloat || ScreenPosition.y < nearFloat || ScreenPosition.x > 1 - nearFloat || ScreenPosition.y > 1 - nearFloat)
                {
                    glowHolder.GetComponent<MeshRenderer>().material.color = inView;
                    totalTimeSpentInPeriferal += Time.deltaTime;                }
                else
                {
                    glowHolder.GetComponent<MeshRenderer>().material.color = SeenColour;
                    totalTimeSpentInFocus += Time.deltaTime;

                }
                isSeen = true;
                totalTimeSpentInFrame += Time.deltaTime;
                lastSeentime = Time.time;

            }
            else
            {
                glowHolder.GetComponent<MeshRenderer>().material.color = notSeen;
                isSeen = false;
            }
        }
        else
        {
            glowHolder.GetComponent<MeshRenderer>().material.color = notSeen;
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

    public float GetTimeInPeriferal()
    {
        return totalTimeSpentInPeriferal;
    }
    public float GetTimeInFocus()
    {
        return totalTimeSpentInFocus;
    }
    public float GetTimeInFrame()
    {
        return totalTimeSpentInFrame;

    }
}
