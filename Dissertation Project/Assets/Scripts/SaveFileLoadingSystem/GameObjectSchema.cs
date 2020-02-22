using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;
namespace ACE.FileSystem
{
   
    [Serializable]
    public class GameObjectSchema : IXmlSerializable
    {
        [XmlArray("ComponentList"), XmlArrayItem(typeof(ISerializableComponent), ElementName="ComponentArrayElement")]
        public List<ISerializableComponent> components;
        [XmlAttribute("GameObject")]
        public GameObject m_objectToSave;
        [XmlAttribute("GameObjectName")]
        public string m_ObjectName;
        public GameObjectSchema()
        {

        }
        public void setGameObject(GameObject objectToSave)
        {
            m_objectToSave = objectToSave;
            m_ObjectName = objectToSave.name;
            components = new List<ISerializableComponent>();
            foreach (Component i in objectToSave.GetComponents<Component>())
            {
                if (!( i is MeshFilter || i is MeshRenderer || i is Transform))
                {


                    Type holder = typeof(SerialisableComponent<>).MakeGenericType(i.GetType());
                    var Save = Activator.CreateInstance(holder);

                    components.Add(Save as SerialisableComponent<Component>);
                }
            }
        }

        public List<ISerializableComponent> GetComponents()
        {
            return components;
            
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            components = new List<ISerializableComponent>();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if(reader.Name == "Component")
                        {
                            SerialisableComponent<Component> componentHolder = new SerialisableComponent<Component>();
                            //This fills in all the info that the component will need including type information
                            ISerializableComponent holder = componentHolder.ReadXml(reader);
                            components.Add(holder);
                        }
                        if(reader.Name == "GameObject")
                        {
                            m_ObjectName = reader.GetAttribute(0);
                        }
                        break;
                    case XmlNodeType.Attribute:
                        if(reader.Name == "GameObjectName")
                        {
                            m_ObjectName = reader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if(reader.Name == "GameObject")
                        {
                            
                            return;
                        }
                        break;
                }
                
            }
           
        }

        public void WriteXml(XmlWriter writer)
        {
            //start with the game object name
          
            writer.WriteStartElement("GameObject");
            writer.WriteAttributeString("GameObjectName", m_ObjectName);
            writer.WriteStartElement("ComponentList");
            foreach (ISerializableComponent i in components)
            { 
                i.WriteXml(writer);
            }
            writer.WriteEndElement();
            
        }

       
        public GameObjectSchema(GameObject objectToSave)
        {
            m_objectToSave = objectToSave;
            m_ObjectName = objectToSave.name;
            List<ISerializableComponent> holdercomponents = new List<ISerializableComponent>();
            foreach (Component i in objectToSave.GetComponents<Component>())
            {
                if (!(i is MeshFilter || i is MeshRenderer || i is Transform))
                {
                    Type holder = typeof(SerialisableComponent<>).MakeGenericType(i.GetType());
                    var Save = Activator.CreateInstance(holder);

                    FieldInfo[] info = holder.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    info[0].SetValue(Save, i);

                    holdercomponents.Add(Save as ISerializableComponent);
                }
            }
            components = holdercomponents;
        }
            
        
    }
}
