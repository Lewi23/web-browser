using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Simple_Web_Browser
{
    class XML<T>
    {
        private XmlDocument doc;
        private string URI;

        

        private XmlDocument bookmarks;

        public XML()
        {
            bookmarks = new XmlDocument();
        }

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





        // https://stackoverflow.com/questions/8334527/save-listt-to-xml-file
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file

        public void writeListToXML<T>(T obj, string filePath)
        {
            
            XmlSerializer writer = new XmlSerializer(typeof(T));

            //var path = Properties.Resources.Bookmarks;
            FileStream file = File.Create(filePath);

            writer.Serialize(file, obj);
            file.Close();
        }

        public List<T> readXMLToList(string filePath)
        {

            List<T> localList = new List<T>();

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                localList = (List<T>)serializer.Deserialize(fileStream);
            }

            return localList;
            
        }

     

    }
}
