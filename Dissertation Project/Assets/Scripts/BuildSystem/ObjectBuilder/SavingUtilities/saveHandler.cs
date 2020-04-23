using ACE.FileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Used to save the object within the object builder
/// </summary>
public class saveHandler : MonoBehaviour
{
    public Toggle Grabbable;
    public GrabBoxScript box;
    public LoadObject objectLoader;
    public ActionDefinitionsController actionController;
    public InputEventController eventController;
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
        Destroy(objectToSave.GetComponent<RotationPreview>());
        
        if (Grabbable != null)
        {
            if (Grabbable.isOn)
            {
                GameObject col = box.GetCollisionBox();

                Destroy(col.GetComponent<GrabBoxScript>());

                col.name = "Handle";
                col.transform.parent = objectToSave.transform;
                col.AddComponent<BoxCollider>();
                Grabable grabRef = col.AddComponent<Grabable>();
                // if it can't be grabbed it must not have any rotation triggers
                actionController.ApplyActionDefinitions(objectToSave, grabRef);
                eventController.ApplyInputEvents(objectToSave);
            }
        }
        objectToSave.AddComponent<Rigidbody>();
        objectToSave.AddComponent<MeshCollider>().convex = true;
        GameObjectCaretaker saver = new GameObjectCaretaker();
        objectToSave.name = GameObject.FindGameObjectWithTag("EditableObject").name;
        saver.SaveObject(objectToSave);
        string CopyLoction = saver.LocationFileSaved;
        string locationOfOBJFile = objectLoader.objString;
        string locationOfMTLFile = objectLoader.matString;
        string OBJFileName = locationOfOBJFile.Split('\\')[locationOfOBJFile.Split('\\').Length - 1];
        string MTLFileName = locationOfMTLFile.Split('\\')[locationOfMTLFile.Split('\\').Length - 1];
        try
        {
            System.IO.File.Copy(locationOfOBJFile, CopyLoction + OBJFileName);
            System.IO.File.Copy(locationOfMTLFile, CopyLoction + MTLFileName);
        }
        catch { 
            //used if saving over an already existing object, hacky but works
        }
        Destroy(objectToSave);
    }
}
