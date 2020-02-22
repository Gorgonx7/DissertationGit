using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using UnityEngine;

namespace ACE.Goals
{
    //Goal files are xml files that define the name of objects and their state required for goal completion
    class GoalLoader
    {
        const string GOALFILELOCATION = "./UDO/Goals/";
        public static void LoadGoal(string FileName, GameObject taskManager)
        {
            List<Goal> loadedGoals = new List<Goal>();
            StreamReader stream = new StreamReader(GOALFILELOCATION + FileName + ".xml");
            XmlReader reader = XmlReader.Create(stream);
            Goal goalToEdit = new Goal();
            while (reader.Read())
            {
                
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //we have a goal
                        if(reader.Name == "Goal")
                        {
                           goalToEdit  = taskManager.AddComponent<Goal>();
                            while (reader.MoveToNextAttribute())
                            {
                                if(reader.Name == "goalName")
                                {
                                    goalToEdit.m_GoalName = reader.Value;
                                } else if(reader.Name == "goalObjectName")
                                {
                                    goalToEdit.GoalObjectName = reader.Value;
                                }
                            }
                        
                        }
                        if(reader.Name == "GoalItem")
                        {
                            reader.MoveToNextAttribute();
                            if(reader.Name == "name")
                            {
                                goalToEdit.importantItems.Add(reader.Value);
                            }
                        }
                        break;
                        
                }
            }

            
        }

       
    }
}
