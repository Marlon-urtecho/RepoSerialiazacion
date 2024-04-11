using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CreateFile
{
    public class XmlObjectSerializer : Iserializer
    {
        public T Deserializable<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public void serializar<T>(T obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using(StreamWriter write = new StreamWriter(fileName))
            {
                serializer.Serialize(write, obj);
            }
        }
    }
}
