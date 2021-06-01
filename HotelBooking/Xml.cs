using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _20200419.util
{
    class Xml
    {
        private string xml;
        public Xml(string xml)
        {
            this.xml = xml;
        }

        public string getTagValue(string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(this.xml);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/configuration/appSettings");
            return nodes[0].SelectSingleNode(value).InnerText;
        }
    }
}
