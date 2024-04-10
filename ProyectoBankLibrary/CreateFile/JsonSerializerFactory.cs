using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile
{
    public class JsonSerializerFactory : ISerializerFactory
    {
        public Iserializer CreateSerializer()
        {
            return new JsonObjectSerializer();
        }
    }
}
