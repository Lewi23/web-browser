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
    
        /// <summary>
        /// Default constructor
        /// </summary>
        public XML()
        {
            
        }

        /// <summary>
        /// Writes the generic object T to the file provided
        /// </summary>
        /// <typeparam name="T">The generic type the class was instantiated with</typeparam>
        /// <param name="obj">The object to be written to file</param>
        /// <param name="filePath">The path of the file to be written to</param>
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
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message);
            } 
        }


        /// <summary>
        /// Returns the data read from file in a List<T>
        /// </summary>
        /// <param name="filePath">The path of the file to be read from</param>
        /// <returns>List<T> of values read from file</returns>
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
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return localList;
            
        }

        /// <summary>
        /// Reads a generic value from file
        /// </summary>
        /// <param name="filePath">The path of the file to be read from</param>
        /// <returns>The generic value read from file</returns>
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            
            return value;
        }
     

    }
}
