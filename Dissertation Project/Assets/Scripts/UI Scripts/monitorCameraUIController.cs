using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Responsible for cycling the camera angles in the old UI
/// </summary>
public class monitorCameraUIController : MonoBehaviour
{
    public List<Texture> renderTextures;
    int currentTexture = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextTexture()
    {
        currentTexture++;
        if (currentTexture == renderTextures.Count)
        {
            currentTexture = 0;
        }

        GetComponent<RawImage>().texture = renderTextures[currentTexture];
        

    }
    public void LastTexture()
    {
        currentTexture--;
        if (currentTexture < 0)
        {
            currentTexture = renderTextures.Count - 1;
        }

        GetComponent<RawImage>().texture = renderTextures[currentTexture];
    }
}
