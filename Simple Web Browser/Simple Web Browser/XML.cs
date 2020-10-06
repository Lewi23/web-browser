using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Simple_Web_Browser
{
    class XML
    {
        // XDocument myxml;
        XmlDocument doc = new XmlDocument();
        

        public XML(string filename)
        {
            // myxml = XDocument.Load(Properties.Resources.Homepage);
            doc.Load(Properties.Resources.Homepage);
        }

        /// <summary>
        /// returns the home page from the Homepage.xml file
        /// </summary>
        public string getHomePageURI()
        {
            // return myxml.Root.Value;
            XmlNode nodeList = doc.SelectSingleNode("//link");
            string link = nodeList.InnerText;
            System.Console.WriteLine(link);
         
            return link;

        }

        /// <summary>
        /// Sets the home page in Homepage.xml
        /// </summary>
        /// <param name="URI"> the value we are setting in the XML document </param>
        public static void writeHomePage(String URI)
        {
            
        }


    }
}
