using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerCore.Models
{
    public class Coche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMaxima { get; set; }

        public int Acelerar()
        {
            this.Velocidad = this.Velocidad + 20;
            if(this.Velocidad > this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }
            return this.Velocidad;
        }

        public int Frenar()
        {
            this.Velocidad = this.Velocidad - 20;
            if(this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;
        }
    }
}
