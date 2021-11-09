using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosLenguaje.Models
{
    public class Director: Empleado
    {
        public Director()
        {
            this.SalarioMinimo = 1400;
            Console.WriteLine("Constructor director sin parametros");
        }
        public Director(int salario):base(12)
        {
            Console.WriteLine("constructor director con parametros");
        }
        public override int GetDiasVacaciones()
        {
            //llamamos al metodo de empleado y recogemos su valor
            int diasempleado = base.GetDiasVacaciones();
            return diasempleado + 20;
        }
    }
}
