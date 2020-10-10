using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Simple_Web_Browser
{
    class XML
    {
        private XmlDocument doc;
        private string URI;

        public XML(string filename)
        {
            doc = new XmlDocument();
            doc.Load(Properties.Resources.Homepage);

            // if(filename == Homepage.xml) { ...
        }

        public string getHomePageURI()
        {
            XmlNode node = doc.SelectSingleNode("//link");
            URI = node.InnerText;
         
            return URI;

        }

        public static void setHomePageURI(String URI)
        {
           
        }


    }
}
