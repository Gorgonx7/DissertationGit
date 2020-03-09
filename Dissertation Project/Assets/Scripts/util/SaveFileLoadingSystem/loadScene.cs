using ACE.Goals;
using Assets.SaveFileLoadingSystem;
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
    public static class loadScene
    {
        public static void LoadPlayerCreatedScene(string fileName)
        {

            if (Directory.Exists("./UDO/Scenes/" + fileName))
            {
                SceneManager.LoadScene("PlayerCreatedScene", LoadSceneMode.Single);
                SceneCaretaker caretaker = new SceneCaretaker();
                PlayerDefinedScene Scene = caretaker.LoadScene(fileName);
                GameObject goalManager = GameObject.FindGameObjectWithTag("TaskManager");
                // Load those goals
                goalManager.GetComponent<GoalManager>().Load(Scene.GetGoalFileName());
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
