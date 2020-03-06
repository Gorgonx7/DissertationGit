using System;
using UnityEngine;
using System.IO;
using System.Xml;

namespace Assets.SaveFileLoadingSystem
{
    class SceneCaretaker
    {
        private const string SCENESAVESTRING = @"./UDO/Scenes/";
        private string LastSavedScene;
        public GameObject[] LoadScene()
        {
            return null;
        }
        public void SaveScene(string[] ObjectsToSave, Vector3[] positions,  string SceneName)
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
