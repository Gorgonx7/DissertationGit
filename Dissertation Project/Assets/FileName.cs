using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileName : MonoBehaviour
{
    public string m_name = "SampleScene";

    public void SwitchScene()
    {
        SceneManager.LoadScene(m_name, LoadSceneMode.Single);
    }

}
