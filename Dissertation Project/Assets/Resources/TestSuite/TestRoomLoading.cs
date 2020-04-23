#if(UNITY_EDITOR)
using ACE.FileSystem;
using Assets.Scripts.util.misc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestRoomLoading : TestCase
{
    // Start is called before the first frame update
    void Start()
    {
        CaseName = this.GetType().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }
    public override void Test()
    {
        try
        {
            string[] scenes = Directory.GetDirectories("./UDO/scenes");
            string roomName = scenes[1].Split('\\')[1];
            SceneCaretaker caretaker = new SceneCaretaker();
            PlayerDefinedScene Scene = caretaker.LoadScene(roomName);
            GlobalVariables.UDOsForScene = Scene.GetObjectArray().ToList();
            foreach (GameObject i in GlobalVariables.UDOsForScene)
            {
                Instantiate(i).tag = "KeyItem";
                
            }
            if(GameObject.FindGameObjectsWithTag("KeyItem").Length == 0)
            {
                failed = true;
            }
            foreach(GameObject j in GameObject.FindGameObjectsWithTag("KeyItem"))
            {
                DestroyImmediate(j);
            }
        }
        catch
        {
            base.failed = true;
        }
        base.Test();
    }
}
#endif
