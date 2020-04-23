using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
namespace ACE.FileSystem
{
    /// <summary>
    /// Caretaker part of the momento pattern, responsible for creating full game objects from momentos (schema)
    /// </summary>
    class GameObjectCaretaker
    {
        private const string SAVEFILELOCATION = "./UDO/SaveFiles/";
        public string LocationFileSaved;
        /// <summary>
        /// Creates an object based off of a schema/momento and loads the model from a specific directory
        /// </summary>
        /// <param name="momento"></param>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public GameObject CreateObject(GameObjectSchema momento, string directoryName)
        {
            GameObject output = ObjectDirectoryManager.LoadObject(RecursiveLoadString, directoryName);
            LocationFileSaved = SAVEFILELOCATION + directoryName;
            GameObject child = output.transform.GetChild(0).gameObject;
            child.transform.parent = null;
            UnityEngine.Object.Destroy(output);
            child.name = momento.m_ObjectName;
            foreach(SerialisableComponent<Component> i in momento.GetComponents())
            {

                i.addToGameObject(child);
                
            }
            return child;
        }
        /// <summary>
        /// Creates an object from a momento 
        /// </summary>
        /// <param name="momento"></param>
        /// <returns></returns>
        public GameObject CreateObject(GameObjectSchema momento)
        {
            GameObject output = new GameObject();
            output.name = momento.m_ObjectName;
            foreach (SerialisableComponent<Component> i in momento.GetComponents())
            {

                i.addToGameObject(output);

            }
            return output;
        }
        private string RecursiveSaveString = SAVEFILELOCATION;
        /// <summary>
        /// used to save the given gameobject entirely
        /// </summary>
        /// <param name="objectToSave"></param>
        public void SaveObject(GameObject objectToSave)
        {
            string previousSaveString = RecursiveSaveString;
            RecursiveSaveString += objectToSave.name + "/";
            if (!Directory.Exists(RecursiveSaveString))
            {
                Directory.CreateDirectory(RecursiveSaveString);
            }
            for(int x = 0; x < objectToSave.transform.childCount; x++)
            {
                SaveObject(objectToSave.transform.GetChild(x).gameObject);  
            }
            GameObjectSchema SaveSchema = new GameObjectSchema(objectToSave);
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));    
            LocationFileSaved = RecursiveSaveString;
            TextWriter writer = new StreamWriter(RecursiveSaveString + "/" + objectToSave.name + ".xml");
            serializer.Serialize(writer, SaveSchema);
            writer.Close();
            RecursiveSaveString = previousSaveString;
        }
        string RecursiveLoadString = SAVEFILELOCATION;
        /// <summary>
        /// used to load a given gameobject from the saved objects
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        public GameObject LoadObject(string ObjectName)
        {
            if(!Directory.Exists(RecursiveLoadString + ObjectName))
            {
                return Resources.Load<GameObject>("BuildableObjects/" + ObjectName);
            }
            string originalString = RecursiveLoadString;
            RecursiveLoadString += ObjectName + "/";
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));
            string[] subObjects = new string[1];
            try
            {
                subObjects = Directory.GetDirectories(RecursiveLoadString);
            } catch(Exception e)
            {
                Debug.Log(e.StackTrace + "\n Message: " + e.Message);
            }
            TextReader reader = new StreamReader(RecursiveLoadString + ObjectName + ".xml");
            GameObjectSchema schema = serializer.Deserialize(reader) as GameObjectSchema;
            reader.Close();
            GameObject root;
            if (originalString == SAVEFILELOCATION)
            {
                root = CreateObject(schema, ObjectName);
            } else
            {
                root = CreateObject(schema); 
            }
            foreach (string subObject in subObjects)
            {
                string objectName = subObject.Split('/')[subObject.Split('/').Length - 1];
                GameObject ChildObject = LoadObject(objectName);
                ChildObject.transform.parent = root.transform;
            }
            RecursiveLoadString = originalString;
            return root;

        }
        /// <summary>
        /// Loads all the objects in the saved objects folder
        /// </summary>
        /// <returns></returns>
        public GameObject[] LoadAllObjects()
        {
            string[] directoriesToLoad = Directory.GetDirectories(SAVEFILELOCATION);
            List<string> objectsToLoad = new List<string>();
            foreach(string i in directoriesToLoad)
            {
                objectsToLoad.Add(i.Split('/')[i.Split('/').Length - 1]);
            }
            List<GameObject> objectsLoaded = new List<GameObject>();
            foreach(string i in objectsToLoad)
            {
                objectsLoaded.Add(LoadObject(i));
            }
            return objectsLoaded.ToArray();
        }
    }
}
