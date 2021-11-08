using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosLenguaje.Models
{
    public class Empleado: Persona
    {
        public Empleado()
        {
            this.SalarioMinimo = 900;
        }
        public int Salario { get; set; }
        //el empleado tiene que tener un salario minimo
        protected int SalarioMinimo { get; set; }

    }
}
