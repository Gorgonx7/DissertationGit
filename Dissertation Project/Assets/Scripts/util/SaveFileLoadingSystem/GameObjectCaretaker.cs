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
    class GameObjectCaretaker
    {
        private const string SAVEFILELOCATION = "./UDO/SaveFiles/";
        public GameObject CreateObject(GameObjectSchema momento, string directoryName)
        {
            GameObject output = ObjectDirectoryManager.LoadObject(SAVEFILELOCATION + directoryName, directoryName);
            
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

        public void SaveObject(GameObject objectToSave)
        {
            GameObjectSchema SaveSchema = new GameObjectSchema(objectToSave);
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));
            if (!Directory.Exists(SAVEFILELOCATION + objectToSave.name)) {
                Directory.CreateDirectory(SAVEFILELOCATION + objectToSave.name);
            }
            TextWriter writer = new StreamWriter(SAVEFILELOCATION + objectToSave.name + "/" + objectToSave.name + ".xml");
            serializer.Serialize(writer, SaveSchema);
            writer.Close();
        }
        public GameObject LoadObject(string ObjectName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));
            TextReader reader = new StreamReader(SAVEFILELOCATION + ObjectName + "/" + ObjectName + ".xml");
            GameObjectSchema schema = serializer.Deserialize(reader) as GameObjectSchema;
            reader.Close();
            return CreateObject(schema, ObjectName);

        }
    }
}
