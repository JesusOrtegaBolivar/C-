using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Plantilla
    {
        public int Hospital_cod { get; set; }
        public int Sala_cod { get; set; }
        public int Empleado_no { get; set; }
        public String Apellido { get; set; }
        public String Funcion { get; set; }
        public String Turno { get; set; }
        public int Salario { get; set; }
    }
}
