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
    
        public XML()
        {
            
        }
   
        
        public void writeToXML<T>(T obj, string filePath)
        {
            try
            {
                using (FileStream file = File.Create(filePath))
                {
                    XmlSerializer writer = new XmlSerializer(typeof(T));
                    writer.Serialize(file, obj);
                    file.Close();
                }
            } catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                
            } 
        }

        public List<T> readXMLToList(string filePath)
        {

            List<T> localList = new List<T>();

            try
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    localList = (List<T>)serializer.Deserialize(fileStream);
                }
            } catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message, "File not found");
            }

            return localList;
            
        }

        public T readXML(string filePath)
        {
            T value = default(T);

            try
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    value = (T)serializer.Deserialize(fileStream);
                } 
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message, "File not found");
            }
            
            return value;
        }
     

    }
}
