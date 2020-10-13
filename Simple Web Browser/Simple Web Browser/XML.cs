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

        public void ToXML<BookmarkArgs>(BookmarkArgs obj)
        {
            
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(BookmarkArgs));

            var path = Properties.Resources.Bookmarks;
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, obj);
            file.Close();
        }

        public List<T> readXML()
        {

            List<T> localList = new List<T>();

            using (FileStream fileStream = File.OpenRead(Properties.Resources.Bookmarks))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                localList = (List<T>)serializer.Deserialize(fileStream);
            }

            return localList;
            
        }

     

    }
}
