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
        public GameObject CreateObject(GameObjectSchema momento)
        {
            GameObject output = new GameObject();
            output.name = momento.m_ObjectName;
            foreach(SerialisableComponent<Component> i in momento.GetComponents())
            {
                i.addToGameObject(output);
                
            }
            return output;
        }

        public void SaveObject(GameObject objectToSave)
        {
            GameObjectSchema SaveSchema = new GameObjectSchema(objectToSave);
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));
            
            TextWriter writer = new StreamWriter("test.xml");
            serializer.Serialize(writer, SaveSchema);
            writer.Close();
        }
        public GameObject LoadObject(string ObjectName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameObjectSchema));
            TextReader reader = new StreamReader("test.xml");
            GameObjectSchema schema = serializer.Deserialize(reader) as GameObjectSchema;
            return CreateObject(schema);

        }
    }
}
