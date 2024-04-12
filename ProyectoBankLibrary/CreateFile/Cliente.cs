using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CreateFile
{
    [Serializable] //clase serializable
    public class Cliente
    {
        //Atributos del cliente 
        public int cuenta {  get; set; }
        public string? firsName {  get; set; }
        public string? LastName { get; set; }
        public double saldo {  get; set; }

    }
}
