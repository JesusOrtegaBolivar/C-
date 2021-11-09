using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FundamentosLenguaje.Helpers;
using FundamentosLenguaje.Models;

namespace FundamentosLenguaje
{
    enum TipoChar { Letras, Numeros, Simbolos }
    class Program
    {
        static void Main(string[] args)
        {
            Coche car1 = new Coche("Opel", "Astra", 250, "Norte");
            int opcion = 0;
            while (opcion != 5)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("1.- Arrancar");
                Console.WriteLine("2.- Acelerar");
                Console.WriteLine("3.- Frenar");
                Console.WriteLine("4.- Girar");
                Console.WriteLine("5.- Salir");
                Console.WriteLine("--------------------");
                Console.WriteLine("6.- Ver informacion");
                opcion = int.Parse(Console.ReadLine());
                
                if(opcion == 1)
                {
                    car1.Arrancar();
                }else if (opcion == 2)
                {
                    Console.WriteLine("Quieres indicar la velocidad");
                    int valor = int.Parse(Console.ReadLine());
                    car1.Acelerar(valor);
                }else if (opcion == 3)
                {
                    Console.WriteLine("Quieres indicar la velocidad");
                    int valor = int.Parse(Console.ReadLine());
                    car1.Frenar(valor);
                }else if (opcion == 4)
                {
                    car1.Girar();
                }else if (opcion == 5)
                {
                    Console.WriteLine("Saliendo del programa");
                } else if (opcion == 6)
                {
                    Console.WriteLine(car1);
                } else
                {
                    Console.WriteLine("Ha ocurrido un error");
                }
            }
        }


        static void NumeroPositivoNegativo()
        {
            Console.WriteLine("Introduce un numero para comprobarlo: ");
            string dato = Console.ReadLine();
            int numero = int.Parse(dato);
            if (numero == 0)
            {
                Console.WriteLine("El numero es igual a 0");
            }
            else if (numero > 0)
            {
                Console.WriteLine("El numero es Positivo");
            } else
            {
                Console.WriteLine("El numero es Negativo");
            }
        }
        static void Mayortresnumeros()
        {
            Console.WriteLine("Introduce 3 numeros: ");
            string dato = Console.ReadLine();
            int numero1 = int.Parse(dato);
            dato = Console.ReadLine();
            int numero2 = int.Parse(dato);
            dato = Console.ReadLine();
            int numero3 = int.Parse(dato);
            int mayor = 0, menor = 0, intermedio = 0;
            if (numero1 > numero2 && numero1 > numero3)
            {
                mayor = numero1;
            } else if (numero2 > numero1 && numero2 > numero3)
            {
                mayor = numero2;
            }else
            {
                mayor = numero3;
            }


            if(numero1 < numero2 && numero1 < numero3)
            {
                menor = numero1;
            } else if (numero2 < numero1 && numero2 < numero3)
            {
                menor = numero2;
            } else
            {
                menor = numero3;
            }

            int suma = (numero1 + numero2 + numero3);
            intermedio = suma - mayor - menor;

            Console.WriteLine("El numero mayor es: " + mayor);
            Console.WriteLine("El numero intermedio es: " + intermedio);
            Console.WriteLine("El numero menor es: " + menor);
        }
        static void DiaNacimiento()
        {
            Console.WriteLine("Introduce tu fecha de nacimiento: ");
            Console.WriteLine("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Año: ");
            int año = int.Parse(Console.ReadLine());
            if(mes == 1)
            {
                mes = 13;
                año -= 1;
            }else if(mes == 2)
            {
                mes = 14;
                año -= 1;
            }
            int operacion1 = ((mes + 1) * 3) / 5;
            int operacion2 = año / 4;
            int operacion3 = año / 100;
            int operacion4 = año / 400;
            int operacion5 = dia + (mes * 2) + año + operacion1 + operacion2 - operacion3 + operacion4 + 2;
            int operacion6 = operacion5 / 7;
            int resultado = operacion5 - (operacion6 * 7);

            if(resultado == 0)
            {
                Console.WriteLine("Sabado");
            }else if (resultado == 1)
            {
                Console.WriteLine("Domingo");
            }else if (resultado == 2)
            {
                Console.WriteLine("Lunes");
            }else if (resultado == 3)
            {
                Console.WriteLine("Martes");
            }else if (resultado == 4)
            {
                Console.WriteLine("Miercoles");
            }else if(resultado == 5)
            {
                Console.WriteLine("Jueves");
            }else
            {
                Console.WriteLine("Viernes");
            }

        }
        static void ConjeturaCollatz() 
        {
            Console.WriteLine("Escribe un numero: ");
            string dato = Console.ReadLine();
            int numero = int.Parse(dato);
            while(numero != 1)
            {
                if(numero % 2 == 0)
                {
                    numero = numero / 2;
                }
                else
                {
                    numero = numero * 3 + 1;
                }
                Console.WriteLine(numero);
            }
        }
        static void NumerosPares()
        {
            Console.WriteLine("Introduce un rango de numeros: Inicial y final");
            int inicio = int.Parse(Console.ReadLine());
            int final = int.Parse(Console.ReadLine());
            for (int i = inicio; i < final; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine("Numero par: " + i);
                }
            }
        }
        static void SumarNumeros()
        {
            Console.WriteLine("Introduce un numero: ");
            int numero = -1;
            int suma = 0;
            while (numero != 0){
                numero = int.Parse(Console.ReadLine());
                suma = suma + numero;
                Console.WriteLine("La suma es: " + suma);
                Console.WriteLine("Introduce un numero: ");
            }
        }
        static void EjemploChar(TipoChar tipo)
        {
            for (int i = 0; i <= 255; i++)
            {
                char letra = (char) i;
                if (tipo == TipoChar.Simbolos)
                {
                    if (char.IsSymbol(letra))
                    {
                        Console.WriteLine(letra);
                    }
                }else if (tipo == TipoChar.Letras)
                {
                    if (char.IsLetter(letra))
                    {
                        Console.WriteLine(letra);
                    }
                }else if(tipo == TipoChar.Numeros)
                {
                    if (char.IsNumber(letra))
                    {
                        Console.WriteLine(letra);
                    }
                }
            }
        }
        static void SumaNumericaString()
        {
            Console.WriteLine("Introduce un texto numerico");
            string texto = Console.ReadLine();
            int suma = 0;
            for (var i = 0; i < texto.Length; i++)
            {
                //propiedad indizada de un conjunto
                char caracter = texto[i];
                //convertimos el caracter a numero
                //En esta conversion recupera el codigo ascii
                //int numero = (int)caracter;
                int numero = int.Parse(caracter.ToString());
                suma += numero;
            }
            Console.WriteLine(suma);
        }
        static void InvertirTextoString(string texto)
        {
            //queremos medir el rendimiento
            //no la reconoce porque no esta en namespace
            //o llamar a System.diagnostics
            Stopwatch krono = new Stopwatch();
            //iniciamos el contador
            krono.Start();
            //recorremos el texto
            for (int i = 0; i < texto.Length; i++)
            {
                char letra = texto[texto.Length - 1];
                texto = texto.Remove(texto.Length - 1, 1);
                texto = texto.Insert(i, letra.ToString());

            }
            Console.WriteLine("----------------------");
            krono.Stop();
            Console.WriteLine(texto);
            Console.WriteLine("Milisegundos tardados: " + krono.Elapsed.TotalMilliseconds);
        }
        static void InvertirTextoStringBuilder(string datos)
        {
            //queremos medir el rendimiento
            //no la reconoce porque no esta en namespace
            //o llamar a System.diagnostics
            Stopwatch krono = new Stopwatch();
            //iniciamos el contador
            krono.Start();
            StringBuilder texto = new StringBuilder();
            texto.Append(datos);
            //añadimos el texto al builder
            //recorremos el texto
            for (int i = 0; i < texto.Length; i++)
            {
                char letra = texto[texto.Length - 1];
                texto = texto.Remove(texto.Length - 1, 1);
                texto = texto.Insert(i, letra.ToString());

            }
            Console.WriteLine("----------------------");
            krono.Stop();
            Console.WriteLine(texto);
            Console.WriteLine("Milisegundos tardados: " + krono.Elapsed.TotalMilliseconds);
        }
        static void EjemploColecciones()
        {
            List<int> numero = new List<int>();
            //al tener tipado nos da errores de compilacion
            numero.Add(45);
            numero.Add(5);
            List<String> nombre = new List<string>();
            nombre.Add("Jesus");
            nombre.Add("Ana");
            nombre.Add("Pedro");
            nombre.Add("Ana");
            foreach(int num in numero)
            {
                Console.WriteLine(num);
            }
            foreach(string nom in nombre)
            {
                Console.WriteLine(nom);
            }
        }
        static void EjemploColecciones2()
        {
            string respuesta = "S";
            List<String> nombres = new List<string>();
            while(respuesta != "N")
            {
                Console.WriteLine("Introduce nombres: ");
                string valor = Console.ReadLine();
                nombres.Add(valor);
                Console.WriteLine("¿Quieres continuar? (S/N): ");
                respuesta = Console.ReadLine();
            }
            foreach(string name in nombres)
            {
                Console.WriteLine(name);
            }
        }

    }
}
