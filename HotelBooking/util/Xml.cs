using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HotelBooking.util
{
    class Xml
    {
        private string xml;
        public Xml(string xml)
        {
            this.xml = xml;
        }

        public void getTagValue()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(this.xml);

            XmlNode xn = doc.DocumentElement.SelectSingleNode("configuration/DbConnEncrypting");
            string s = xn.OuterXml;
        }
    }
}
