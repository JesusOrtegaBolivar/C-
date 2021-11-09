using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosLenguaje.Models
{
    public class Coche
    {
        public Coche(String Marca, String Modelo, int VelocidadMaxima, String Direccion)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.VelocidadActual = 0;
            this.VelocidadMaxima = VelocidadMaxima;
            this.Direccion = Direccion;
            this.Estado = 0;
        }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int VelocidadActual { get; set; }
        private int VelocidadMaxima { get; set; }
        public String Direccion { get; set; }
        private int Estado { get; set; }
        public void  Acelerar(int velocidad = 0)
        {
            if(this.VelocidadActual == this.VelocidadMaxima)
            {
                throw new Exception("No se puede acelerar mas");
            }else
            {
                if (velocidad == 0)
                {
                    this.VelocidadActual = this.VelocidadActual + 20;
                }
                else
                {
                    this.VelocidadActual = this.VelocidadActual + velocidad;
                }
            }
            
        }
        public void Arrancar()
        {
            if(this.Estado == 0)
            {
                this.Estado = 1;
            }
            else
            {
                Console.WriteLine("El coche esta arrancado");
            }
        }
        public void Frenar(int velocidad = 0)
        {
            if(this.VelocidadActual == 0)
            {
                Console.WriteLine("El coche no puede frenar mas");
            }else if(velocidad == 0)
            {
                this.VelocidadActual = this.VelocidadActual - 20;
            }
            else
            {
                this.VelocidadActual = this.VelocidadActual - velocidad;
            }
        }
        public void Girar(int Direccion = 0)
        {
            if (Direccion == 1)
            {
                this.Direccion = "Norte";
            }else if (Direccion == 2)
            {
                this.Direccion = "Este";
            }else if (Direccion == 3)
            {
                this.Direccion = "Sur";
            }else if (Direccion == 4)
            {
                this.Direccion = "Oeste";
            }else
            {
                Console.WriteLine("No se ha introducido bien el valor");
            }
        }
        public override string ToString()
        {
            return "Marca: " + this.Marca + " Modelo: " + this.Modelo + " Valocidad: " + this.VelocidadActual + " Direccion: " + this.Direccion;
        }
    }
}
