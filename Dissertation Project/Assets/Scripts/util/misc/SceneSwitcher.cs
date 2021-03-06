﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Responsible for loading difference scenes
/// </summary>
namespace Assets
{
    class SceneSwitcher : MonoBehaviour
    {
        public string SceneName = "LoadingScene";

        public void switchScene()
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
        
    }
}
