using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using Dummiesman;
public class LoadObject : MonoBehaviour
{
    public string objString;
    public string matString;
    public void loadModel()
    {
        string[] objFileString = StandaloneFileBrowser.OpenFilePanel("Select a model file (obj)", "./", new ExtensionFilter[] { new ExtensionFilter("obj", new string[] { "obj" }) }, false);
        string[] matFileString = StandaloneFileBrowser.OpenFilePanel("Select a material file (mtl)", "./", new ExtensionFilter[] { new ExtensionFilter("mtl", new string[] { "mtl" }) }, false);
        objString = objFileString[0];
        matString = matFileString[0];
        Debug.Log(objFileString[0]);
        OBJLoader loader = new OBJLoader();
        GameObject loadedObject = loader.Load(objFileString[0], matFileString[0]);
        loadedObject.tag = "EditableObject";
        loadedObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Camera.main.rect.width / 2, Camera.main.rect.height / 2, 10.0f) + new Vector3(0,3,0));
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
