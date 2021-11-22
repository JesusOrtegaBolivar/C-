using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Doctor
    {
        public int Hospital_Cod { get; set; }
        public String Doctor_no { get; set; }
        public String Apellido { get; set; }
        public String Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
