using System;

namespace FundamentosLenguaje
{
    class Program
    {
        static void Main(string[] args)
        {
            Mayortresnumeros();
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


    }
}
