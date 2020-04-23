using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
namespace ACE.FileSystem
{
    /// <summary>
    /// interface to store template classes in a list without knowing thier explicit type
    /// </summary>
    public interface ISerializableComponent
    {
        Type GetSerializedType();
        void WriteXml(XmlWriter writer);
        SerialisableComponent<Component> ReadXml(XmlReader reader);
    }
}
