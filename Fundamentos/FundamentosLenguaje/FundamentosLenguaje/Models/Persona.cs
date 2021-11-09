using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosLenguaje.Models
{
    public enum Paises { España, Francia, Alemania }

    public class Persona
    {
        //Constructor
        public Persona()
        {
            this.Nacionalidad = Paises.España;
            this.Edad = 0;
            Console.WriteLine("Constructor de persona");
        }
        public Persona(String nombre, String Apellidos)
        {
            this.Nombre = nombre;
            this.Apellidos = Apellidos;
        }
        public void ConvertirDescripcion()
        {
            for (int i = 0; i < this._Descripcion.Length; i++)
            {
                this._Descripcion[i] = this._Descripcion[i].ToUpper();
            }
        }
        public virtual String GetNombreCompleto()
        {
            Console.WriteLine("GetNombreCompleto Persona");
            return this.Nombre + " " + this.Apellidos;
        }
        //poliformismo
        public String GetNombreCompleto(bool orden)
        {
            if (orden == true)
            {
                return this.Apellidos + " " + this.Nombre;
            }
            else
            {
                return GetNombreCompleto();
            }
        }
        private string[] _Descripcion = new String[3];
        public String this[int indice]
        {
            get { return this._Descripcion[indice]; }
            set { this._Descripcion[indice] = value; }
        }
        public Paises Nacionalidad { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        private int _Edad;
        //Cuando se trabaja con propiedades siempre se utiliza un campo de propiedad
        //Declaramos una propiedad Edad
        public int Edad
        {
            get { return _Edad; }
            set { 
                if (value < 0)
                {
                    //Hacemos algo
                    throw new Exception("La edad no puede ser negativa");
                } else
                {
                    _Edad = value;
                }
            }
        }
    }
}
