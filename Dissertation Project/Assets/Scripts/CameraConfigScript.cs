using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfigScript : MonoBehaviour
{
    public Shader ReplacementShader;
    // Start is called before the first frame update
    [ExecuteInEditMode]
    void Start()
    {
        if (ReplacementShader)
        {
            GetComponent<Camera>().RenderWithShader(ReplacementShader, "MonitorOnly");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
