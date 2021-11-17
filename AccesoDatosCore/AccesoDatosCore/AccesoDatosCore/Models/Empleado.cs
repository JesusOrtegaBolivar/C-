using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Empleado
    {
        public String Apellido { get; set; }
        public int IdEmpleado { get; set; }
        public String Oficio { get; set; }
        public int Salario { get; set; }
    }
}
