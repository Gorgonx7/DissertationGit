using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Controller for the main menu
/// </summary>
public class uiController : MonoBehaviour
{
    public void LoadDesign() {
        Debug.Log("Load Design");
        SceneManager.LoadScene("RoomBuilder", LoadSceneMode.Single);
    }
    public void LoadObjectBuilder()
    {
        Debug.Log("Load Object Builder");
        SceneManager.LoadScene("ObjectBuilder", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
