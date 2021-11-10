using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Doctor
    {
        public int hospital_cod { get; set; }
        public int doctor_no { get; set; }
        public String apellido { get; set; }
        public String especialidad { get; set; }
        public int salario { get; set; }
    }
}
