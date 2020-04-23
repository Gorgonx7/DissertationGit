﻿using ACE.Goals;

using Assets.Scripts.util.misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ACE.FileSystem
{
    /// <summary>
    /// Loads a full scene with it's object
    /// </summary>
    public static class loadScene
    {
       
        public static void LoadPlayerCreatedScene(string fileName)
        {
            if(fileName == "SampleScene")
            {
                SceneManager.LoadScene("CalibrationScene", LoadSceneMode.Single);

            } else if (Directory.Exists("./UDO/Scenes/" + fileName))
            {
                SceneManager.LoadScene("PlayerCreatedScene", LoadSceneMode.Single);
                SceneCaretaker caretaker = new SceneCaretaker();
                PlayerDefinedScene Scene = caretaker.LoadScene(fileName);
                GlobalVariables.UDOsForScene = Scene.GetObjectArray().ToList();
                
                
                // Load those goals
                GlobalVariables.GoalXML = Scene.GetGoalFileName();
                //All objects should be deployed into the scene by default, no list of these objects is required because they are
                // A) referenced by the unity engine
                // B) referenced by the tag "Key Item"
                // C) not reference by other scripts
                
            }
        }
        public static List<Texture2D> GetSceneTextures()
        {
            if (Directory.Exists("./UDO/Scenes"))
            {
                string[] scenes = Directory.GetDirectories("./UDO/Scenes");
                List<Texture2D> screenShots = new List<Texture2D>();
                foreach(string i in scenes)
                {
                    byte[] imageData = File.ReadAllBytes(i);
                    Texture2D holder = new Texture2D(800, 400, TextureFormat.ARGB32, false);
                    holder.LoadImage(imageData);
                    screenShots.Add(holder);
                }
                return screenShots;
            }
            return new List<Texture2D>();
        }
    }
}
