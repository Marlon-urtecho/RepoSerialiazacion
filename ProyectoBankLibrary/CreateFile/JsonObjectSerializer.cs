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
            try
            {
                string json = File.ReadAllText(fileName);

                if (string.IsNullOrEmpty(json))
                {
                    throw new JsonException("El archivo JSON está vacío o no contiene datos.");
                }

                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        args.ErrorContext.Handled = true;
                    }
                };

                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error al leer el archivo '{fileName}': {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Error al deserializar el JSON en '{fileName}': {ex.Message}", ex);
            }
        }

        public void serializar<T>(T obj, string fileName)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(fileName, json);
        }
    }
}
