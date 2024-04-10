using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateFile
{
    public interface ISerializerFactory
    {
        Iserializer CreateSerializer();
    }
}
