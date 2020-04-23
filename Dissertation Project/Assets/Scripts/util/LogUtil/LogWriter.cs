using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assets.LogUtil
{
    /// <summary>
    /// writes the log to the file system in XML
    /// </summary>
    class LogWriter
    {
        const string LOGDIRECTORY = "./UDO/RawLogs/";
        public static void WriteLog(string LogName, Assets.LogUtil.LogObject[] ObjectsToLog)
        {
            string workingDirectory = LOGDIRECTORY + (DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day);
            if (!Directory.Exists(workingDirectory))
            {
                Directory.CreateDirectory(workingDirectory);
            }
            //Now to create the XML file for the log directly
            TextWriter streamWriter = new StreamWriter(workingDirectory + "/" + LogName + ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(streamWriter, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("LogRoot");
            writer.WriteAttributeString("Creation_Date_and_time", DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second);
            writer.WriteAttributeString("Number_of_Logs", ObjectsToLog.Length.ToString());
            foreach(LogObject log in ObjectsToLog)
            {
                log.Write(writer);
            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
    }
}
