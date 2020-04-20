using Assets.SaveFileLoadingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ACE.Goals;
namespace ACE.FileSystem
{
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
            string[] ObjectNamesToSave = new string[placedObjects.Length + 1];
            Vector3[] objectLocations = new Vector3[placedObjects.Length + 1];
            for (int i = 0; i < placedObjects.Length; i++)
            {
                string holder = placedObjects[i].name;
                holder = holder.Replace("(Clone)", "");
                if (holder == "Player Holder")
                {
                    // save the player holder in a certain way
                }
                ObjectNamesToSave[i] = holder;
                objectLocations[i] = placedObjects[i].transform.position;
            }
            GameObject floor = GameObject.FindGameObjectWithTag("Floor");
            
            saveText = saveName.GetComponent<Text>().text;
            SceneCaretaker sceneCaretaker = new SceneCaretaker();
            GoalSaveStruct[] goalsToSave = GoalUIPannel.GetGoalsToSave();
            GoalSaver.SaveGoal(saveText, goalsToSave);
            sceneCaretaker.SaveScene(ObjectNamesToSave, objectLocations, saveText, saveText);
            cam.CamCapture(sceneCaretaker.GetLastFileLocation());
        }
    }
}