
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ACE.Goals;
namespace ACE.FileSystem
{
    /// <summary>
    /// saves a scene, all its objects and their positions
    /// </summary>
    public class saveScene : MonoBehaviour
    {
        BuildController control;
        public GameObject saveName;
        private string saveText;
        public ScreenShotController cam;
        public GoalPanelController GoalUIPannel;
        // Start is called before the first frame update
        void Start()
        {
            control = GameObject.FindGameObjectWithTag("BuildController").GetComponent<BuildController>();
        }


        public void SaveScene()
        {
            saveText = saveName.GetComponent<Text>().text;
            GameObject[] placedObjects = control.GetPlacedObjects();
            List<string> ObjectNamesToSave = new List<string>();
            List<Vector3> objectLocations = new List<Vector3>();
            for (int i = 0; i < placedObjects.Length; i++)
            {
                string holder = placedObjects[i].name;
                if (GameObject.Find(holder) != null)
                {
                    holder = holder.Replace("(Clone)", "");

                    ObjectNamesToSave.Add(holder);
                    objectLocations.Add(placedObjects[i].transform.position);
                }
            }
            GameObject floor = GameObject.FindGameObjectWithTag("Floor");
            
            saveText = saveName.GetComponent<Text>().text;
            SceneCaretaker sceneCaretaker = new SceneCaretaker();
            GoalSaveStruct[] goalsToSave = GoalUIPannel.GetGoalsToSave();
            GoalSaver.SaveGoal(saveText, goalsToSave);
            sceneCaretaker.SaveScene(ObjectNamesToSave.ToArray(), objectLocations.ToArray(), saveText, saveText);
            cam.CamCapture(sceneCaretaker.GetLastFileLocation());
        }
    }
}