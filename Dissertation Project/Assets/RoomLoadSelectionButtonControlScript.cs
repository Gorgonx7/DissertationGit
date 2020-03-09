using ACE.FileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomLoadSelectionButtonControlScript : MonoBehaviour
{
    public string RoomToLoad = "SampleScene";
    const string SCENEFOLDERLOCATION = "./UDO/Scenes/";
    // Start is called before the first frame update
    void Start()
    {

        Texture2D screenShot = ScreenShotController.LoadTexture(SCENEFOLDERLOCATION + RoomToLoad + "/" + "screenshot.png");
        transform.GetChild(1).GetComponent<RawImage>().texture = screenShot;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {

        }
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
