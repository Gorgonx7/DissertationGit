using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ACE.Goals
{
    /// <summary>
    /// Responsible for saving goals, this struct acts as the momento for the goal class, not defined as its own class as it's faster to use a struct for saving, and this is not as complex as saving a full game object
    /// </summary>
    public struct GoalSaveStruct
    {
        string m_goalName;
        string m_goalObjectName;
        string[] m_associatedObjects;
        public GoalSaveStruct(string name, string goalObject, string[] associatedObjects)
        {
            m_goalName = name;
            m_goalObjectName = goalObject;
            m_associatedObjects = associatedObjects;
        }
        public string GetName()
        {
            return m_goalName;
        }
        public string GetGoalObject()
        {
            return m_goalObjectName;
        }
        public string[] GetGoalObjectNames()
        {
            return m_associatedObjects;
        }
    }
    /// <summary>
    /// Simple struct that writes the XML for the above struct
    /// </summary>
   public static class GoalSaver
    {
        const string GOALFILELOCATION = "./UDO/Goals/";
        public static void SaveGoal(string FileName, GoalSaveStruct[] saveStructs)
        {
            List<Goal> loadedGoals = new List<Goal>();
            if (!Directory.Exists(GOALFILELOCATION))
            {
                Directory.CreateDirectory(GOALFILELOCATION);
            }
            StreamWriter stream = new StreamWriter(GOALFILELOCATION + FileName + ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(stream, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("GoalSet");
            foreach (GoalSaveStruct i in saveStructs)
            {
                
                writer.WriteStartElement("Goal");
                writer.WriteAttributeString("goalName", i.GetName());
                writer.WriteAttributeString("goalObjectName", i.GetGoalObject());
                
                foreach(string j in i.GetGoalObjectNames())
                {
                    writer.WriteStartElement("GoalItem");
                    writer.WriteAttributeString("name", j);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            stream.Close();

        }
    }
}
