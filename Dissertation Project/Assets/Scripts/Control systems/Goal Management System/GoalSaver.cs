﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ACE.Goals
{
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
            foreach(GoalSaveStruct i in saveStructs)
            {
                writer.WriteStartDocument();
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

        }
    }
}
