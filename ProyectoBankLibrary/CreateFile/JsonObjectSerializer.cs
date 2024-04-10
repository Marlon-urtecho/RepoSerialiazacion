using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CreateFile
{
    public class JsonObjectSerializer : Iserializer
    {
        public T Deserializable<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void serializar<T>(T obj, string fileName)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(fileName, json);
        }
    }
}
