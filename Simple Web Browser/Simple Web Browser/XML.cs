﻿using System;
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
    
        public XML()
        {
            
        }
        // https://stackoverflow.com/questions/8334527/save-listt-to-xml-file
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file

        //MIGHT WANT TO RENAME
        public void writeToXML<T>(T obj, string filePath)
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

        public T readXML(string filePath)
        {
            T value;

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                value = (T)serializer.Deserialize(fileStream);
            }

            return value;

        }
     

    }
}
