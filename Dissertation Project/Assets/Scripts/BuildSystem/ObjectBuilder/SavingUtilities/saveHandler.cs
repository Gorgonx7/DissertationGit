using ACE.FileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveHandler : MonoBehaviour
{
    public Toggle Grabbable;
    public GrabBoxScript box;
    public LoadObject objectLoader;
    private GameObject CreateFinalGameObjectToSave()
    {
        GameObject output = GameObject.FindGameObjectWithTag("EditableObject");
        output = output.transform.GetChild(0).gameObject;
        output.transform.parent = null;
        return output;
    }
    public void Save()
    {
        GameObject objectToSave = CreateFinalGameObjectToSave();
        if (Grabbable.isOn)
        {
            GameObject col = box.GetCollisionBox();
            
            Destroy(col.GetComponent<GrabBoxScript>());
            
            col.name = "Handle";
            col.transform.parent = objectToSave.transform;
        }
        objectToSave.AddComponent<Rigidbody>();
        objectToSave.AddComponent<MeshCollider>().convex = true;
        GameObjectCaretaker saver = new GameObjectCaretaker();
        objectToSave.name = "TestObjectPleaseWork";
        saver.SaveObject(objectToSave);
        string CopyLoction = saver.LocationFileSaved;
        string locationOfOBJFile = objectLoader.objString;
        string locationOfMTLFile = objectLoader.matString;
        string OBJFileName = locationOfOBJFile.Split('\\')[locationOfOBJFile.Split('\\').Length - 1];
        string MTLFileName = locationOfMTLFile.Split('\\')[locationOfMTLFile.Split('\\').Length - 1];
        System.IO.File.Copy(locationOfOBJFile, CopyLoction + OBJFileName);
        System.IO.File.Copy(locationOfMTLFile, CopyLoction + MTLFileName);
        //Pray

    }
}
