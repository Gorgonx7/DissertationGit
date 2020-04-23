using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;
namespace ACE.FileSystem
{
    /// <summary>
    ///  Momento class for any custom gameobject within the system
    /// </summary>
    [Serializable]
    public class SerialisableComponent<T> : ISerializableComponent where T : Component
    {
        //The concists of everything that a custom object may need to be serialised
        //This specific schema has no data on position, rotation, only graphical and mechanical 
        [XmlAttribute("Component")]
        private T m_Component;
        [XmlAttribute("ComponentType")]
        Type componentType;
        Dictionary<string, ACE_PropertyField> componentVariable = new Dictionary<string, ACE_PropertyField>();
        public SerialisableComponent(T pComponent)
        {
            m_Component = pComponent;
            componentType = pComponent.GetType();
        }
        public SerialisableComponent()
        {
            componentType = typeof(T);
        }
        public void SetComponent(T pComponent)
        {
            m_Component = pComponent;
        }
        public T GetComponent()
        {
            return m_Component;
        }
        public new Type GetType()
        {
            return componentType;
        }
        public void addToGameObject(GameObject objectToAttatchTo)
        {
            Component comp;
            if (componentType == Type.GetType("UnityEngine.Transform"))
            {
                comp = objectToAttatchTo.transform;
                // TODO decerialse more transform stuff as scale currently is not being set correctly, possibly redirect transforms to their own function

            }
            comp = objectToAttatchTo.AddComponent(componentType);
            foreach (KeyValuePair<String, ACE_PropertyField> i in componentVariable)
            {
                object value = i.Value.m_Val;
                if(Type.GetType(i.Value.m_type) == null && Type.GetType("UnityEngine." + i.Value.m_type + ", UnityEngine") != null)
                {
                    if (Type.GetType("ACE.FileSystem.StringToUnity").GetMethod("StringTo" + i.Value.m_type) != null)
                    {
                        componentType.GetProperty(i.Key).SetValue(comp, Type.GetType("ACE.FileSystem.StringToUnity").GetMethod("StringTo" + i.Value.m_type).Invoke(null, new object[] { i.Value.m_Val }));
                    }
                }
                else if (Type.GetType("System." + i.Value.m_type) != null)
                {
                    
                    string typeString = i.Value.m_type;
                    
                    if ((Type.GetType("System." + typeString).GetMethod("Parse", new[] { typeof(string) }) != null)){
                        if (componentType.GetProperty(i.Key) != null) {
                            componentType.GetProperty(i.Key).SetValue(comp, Type.GetType("System." + typeString).GetMethod("Parse", new[] { typeof(string) }).Invoke(null, new object[] { i.Value.m_Val }));
                        }
                        else
                        {
                            componentType.GetField(i.Key).SetValue(comp, Type.GetType("System." + typeString).GetMethod("Parse", new[] { typeof(string) }).Invoke(null, new object[] { i.Value.m_Val }));

                        }
                    }
                }
                else
                {
                    PropertyInfo info = componentType.GetProperty(i.Key);
                    if (info != null)
                    {
                        info.SetValue(comp, value);
                    }
                    else
                    {
                        if (componentType.GetField(i.Key) != null)
                        {
                            componentType.GetField(i.Key).SetValue(comp, value);
                        }
                    }
                }
                
                

            }
            comp = m_Component;
        }

            public Type GetSerializedType()
            {
                return componentType;
            }

            public XmlSchema GetSchema()
            {
                return null;
            }

            public SerialisableComponent<Component> ReadXml(XmlReader reader)
            {
                SerialisableComponent<Component> Output = new SerialisableComponent<Component>();
                if (reader.AttributeCount > 0)
                {
                    string type = reader.GetAttribute(0);
                    if (type.Contains("UnityEngine"))
                    {
                        type = type + ", UnityEngine";
                    }
                    componentType = Type.GetType(type);

                    Output.componentType = this.componentType;

                }
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == componentType.ToString())
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                PropertyInfo propinfo = componentType.GetProperty(reader.Name);
                                string fieldName = "";
                                if (propinfo == null) {
                                    FieldInfo FieldInfo = componentType.GetField(reader.Name);
                                    if (FieldInfo != null)
                                    {
                                        fieldName = FieldInfo.FieldType.Name;
                                    }
                                }
                                else {
                                    fieldName = propinfo.PropertyType.Name;
                                }
                                     
                                    Output.componentVariable.Add(reader.Name, new ACE_PropertyField(fieldName, reader.Value));
                                }
                            }
                            break;
                        case XmlNodeType.Attribute:
                            if (reader.Name == "Type")
                            {
                                componentType = Type.GetType(reader.Value);
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == "Component")
                            {
                                return Output;
                            }
                            break;
                    }
                }
                return Output;
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("Component");
                writer.WriteAttributeString("Type", componentType.ToString());
                writer.WriteStartElement(componentType.ToString());
                PropertyInfo[] info = componentType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                foreach (PropertyInfo i in info)
                {
                    if (i.CanWrite)
                    {
                        if (i.GetValue(m_Component) != null)
                        {
                            writer.WriteAttributeString(i.Name, i.GetValue(m_Component).ToString());
                        }
                    }
                }
            FieldInfo[] Fieldinfo = componentType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach(FieldInfo i in Fieldinfo)
            {
                if(i.GetValue(m_Component) != null)
                {
                    writer.WriteAttributeString(i.Name, i.GetValue(m_Component).ToString());
                }
            }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }


        }
  }

public struct ACE_PropertyField
{
    private string _m_Val;
    public string m_Val
    {
        get
        {
            return _m_Val;
        }
        set
        {
            _m_Val = value;
        }
    }
    private string _m_type;
    public string m_type
    {
        get
        {
            return _m_type;
        }
        set
        {
            _m_type = value;
        }
    }
    public ACE_PropertyField(string type, string valuePair)
    {
        _m_Val = (valuePair);
        _m_type = type;
    }
}