﻿using ACE.FileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum Filter
{
    Sample, UDO
}
public class RoomLoadSelectionButtonControlScript : MonoBehaviour
{
    public string RoomToLoad = "SampleScene";
    const string SCENEFOLDERLOCATION = "./UDO/Scenes/";
    public Filter filter = Filter.Sample;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    
    public void LoadRoom()
    {
        loadScene.LoadPlayerCreatedScene(RoomToLoad);

    }
   
    private void OnEnable()
    {

        Texture2D screenShot = ScreenShotController.LoadTexture(SCENEFOLDERLOCATION + RoomToLoad + "/" + "screenshot.png");
        transform.GetChild(1).GetComponent<RawImage>().texture = screenShot;
    }
}
