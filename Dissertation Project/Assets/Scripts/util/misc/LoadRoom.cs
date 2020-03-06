using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using SFB;

public class LoadRoom : MonoBehaviour
{
    public GameObject currentRoom;
    public void LoadGLB()
    {
        string[] objFileString = StandaloneFileBrowser.OpenFilePanel("Select a model file (obj)", "./", new ExtensionFilter[] { new ExtensionFilter("glb", new string[] { "glb" }) }, false);
        if (objFileString.Length < 1)
        {
            return;
        }
        Destroy(currentRoom);
        GameObject result = Importer.LoadFromFile(objFileString[0]);
        result.transform.position = new Vector3(0, 0, 10);
        currentRoom = result;
    }
}
