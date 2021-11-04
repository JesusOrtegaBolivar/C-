using System;

namespace FundamentosLenguaje
{
    class Program
    {
        static void Main(string[] args)
        {
            SumarNumeros();
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

    }
}
