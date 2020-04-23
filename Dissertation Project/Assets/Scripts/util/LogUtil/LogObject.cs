using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/// <summary>
/// An object that is used for storing a log in the log output
/// </summary>
namespace Assets.LogUtil
{
    class LogObject
    {
        public string LogString
        {
            get;
            private set;
            
        }
        public DateTime dateTime
        {
            get;
            private set;
        }
        public LogObject(string log)
        {
            LogString = log;
            dateTime = DateTime.Now;
        }
        public String GetXML()
        {
            return "<Log Time=\"" + dateTime.ToString() + "\" LogString=\"" + LogString + "\"/>";
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement("Log");
            writer.WriteAttributeString("Time", dateTime.ToString());
            writer.WriteAttributeString("LogString", LogString);
            writer.WriteEndElement();
        }
    }
}
