using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    public void LoadDesign() {
        Debug.Log("Load Design");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
