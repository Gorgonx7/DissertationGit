using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This is the root of the log system
/// This system will record log objects and export them to xml using encoding
/// This is not a serialized system
/// The topology 
/// </summary>

namespace Assets.LogUtil
{
    class LogManager
    {
        public static List<List<LogObject>> LogObjects = new List<List<LogObject>>();
        public static List<LogListener> LogListeners = new List<LogListener>();
        private static void UpdateLogListener(string LogString)
        {
            foreach(LogListener i in LogListeners)
            {
                i.CreateNewLog(LogString);
            }
        }

        public static void Log(string LogString)
        {
            try
            {
                LogObjects[0].Add(new LogObject(LogString));
            } catch
            {
                LogObjects.Add( new List<LogObject>());
                LogObjects[0].Add(new LogObject(LogString));
            }
            UpdateLogListener(LogString);
        }
        public static void Log(string LogString, int log)
        {
            try
            {

                LogObjects[log].Add(new LogObject(LogString));
            }

            catch
            {
                LogObjects.Add( new List<LogObject>());
                LogObjects[log].Add(new LogObject(LogString));
            }
            UpdateLogListener(LogString);

        }
        public static void SaveLog()
        {
            for(int i = 0; i < LogObjects.Count; i++)
            {
                LogWriter.WriteLog(DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + i.ToString(), LogObjects[i].ToArray());
            }
        }
    }
}
