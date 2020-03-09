using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace ACE.FileSystem
{
    public struct PlayerDefinedScene
    {
        GameObject[] m_objects;
        string m_SceneName;
        string m_GoalFileName;
        public PlayerDefinedScene(string SceneName, string GoalFileName, GameObject[] objects)
        {
            m_SceneName = SceneName;
            m_GoalFileName = GoalFileName;
            m_objects = objects;
        }
        public string GetSceneName()
        {
            return m_SceneName;
        }
        public string GetGoalFileName()
        {
            return m_GoalFileName;
        }
        public GameObject[] GetObjectArray()
        {
            return m_objects;
        }
    }
    class SceneCaretaker
    {
        private const string SCENESAVESTRING = @"./UDO/Scenes/";
        private string LastSavedScene;
        public PlayerDefinedScene LoadScene(string SceneName)
        {
            string SavedSceneName = "";
            string GoalFileName = "";
            List<GameObject> ObjectsToLoad = new List<GameObject>();
            if (Directory.Exists(SCENESAVESTRING + "/" + SceneName))
            {
                StreamReader stream = new StreamReader(SCENESAVESTRING + "/" + SceneName + "/" + SceneName + ".xml");
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                XmlReader reader = XmlReader.Create(stream, xmlReaderSettings);
                reader.ReadStartElement();
                if(reader.Name == "Scene")
                {
                    reader.MoveToNextAttribute();
                    if(reader.Name == "Name")
                    {
                        SavedSceneName = reader.Value;
                    }
                    reader.MoveToNextAttribute();
                    if(reader.Name == "GoalFile")
                    {
                        GoalFileName = reader.Value;
                    }
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                GameObjectCaretaker gameObjectSchema = new GameObjectCaretaker();
                                GameObject holder = gameObjectSchema.LoadObject(reader.Name);
                                reader.MoveToNextAttribute();
                                holder.transform.position = StringToUnity.StringToVector3(reader.Value);
                                break;
                            
                        }
                    }
                }
            }
            return new PlayerDefinedScene(SavedSceneName, GoalFileName, ObjectsToLoad.ToArray());
        }
        /// <summary>
        /// Used to save scenes made in the level creator
        /// </summary>
        /// <param name="ObjectsToSave"></param>
        /// <param name="positions"></param>
        /// <param name="SceneName"></param>
        public void SaveScene(string[] ObjectsToSave, Vector3[] positions,  string SceneName, string goalFileName)
        {
            if (!Directory.Exists(SCENESAVESTRING + "/" + SceneName))
            {
                Directory.CreateDirectory(SCENESAVESTRING + "/" + SceneName);
            }
            LastSavedScene = SCENESAVESTRING + "/" + SceneName + "/";
            StreamWriter stream = new StreamWriter(SCENESAVESTRING + "/" + SceneName + "/" + SceneName + ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(stream, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Scene");
            writer.WriteAttributeString("Name", SceneName);
            writer.WriteAttributeString("GoalFile", goalFileName);
            for(int i = 0; i < ObjectsToSave.Length; i++)
            {
                writer.WriteStartElement(ObjectsToSave[i]);
                writer.WriteAttributeString("Position", positions[i].ToString());
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
        public string GetLastFileLocation()
        {
            return LastSavedScene;
        }
    }
}
