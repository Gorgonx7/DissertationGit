using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI;
using System.Xml;

namespace Assets.Log2HTML
{
    class Log2HTML
    {
        public void generate(string LogLocation)
        {

            TextWriter stream = new StreamWriter(LogLocation);
            TextReader streamReader = new StreamReader(LogLocation);
            XmlReader reader = XmlReader.Create(streamReader);
            
           // HtmlTextWriter writer = new HtmlTextWriter(stream);
            // The goal for this is to create a basic usable log system that details enough information
            //writer.RenderBeginTag(HtmlTextWriterTag.H1);
            

        }
    }
}
