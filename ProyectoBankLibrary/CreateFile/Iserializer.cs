using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile
{
    public interface Iserializer
    {
        void serializar<T>(T obj, string fileName);

        T Deserializable<T>(string fileName);

    }
}
