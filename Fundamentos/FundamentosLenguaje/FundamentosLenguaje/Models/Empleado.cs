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
            Console.WriteLine("Constructor de empleado sin parametros");
        }
        public Empleado(int salario)
        {
            Console.WriteLine("Constructor empleado con parametros");
        }
        public int Salario { get; set; }
        //el empleado tiene que tener un salario minimo
        protected int SalarioMinimo { get; set; }
        public override String GetNombreCompleto()
        {
            Console.WriteLine("GetNombreCompleto Empleado");
            return this.Nombre + " " + this.Apellidos + " " + this.Salario;
        }
        public override string ToString()
        {
            return this.Nombre + " " + this.Apellidos + " " + this.SalarioMinimo;
        }
        public virtual int GetDiasVacaciones()
        {
            //empleado 22 dias
            return 22;
        }
    }
}
