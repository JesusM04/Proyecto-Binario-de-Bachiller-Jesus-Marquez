using System;

namespace Proyecto_Binario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Binario binario1 = new Binario();
            Binario binario2 = new Binario();

            int Opcion;

            do
            {
                Console.WriteLine("+----------------------------------------------+");
                Console.WriteLine("|               MENÚ DE OPCIONES               |");
                Console.WriteLine("+----------------------------------------------+");
                Console.WriteLine("|                                              |");
                Console.WriteLine("|  1. Conversion de dos numeros a Binario      |");
                Console.WriteLine("|  2. Suma Binaria                             |");
                Console.WriteLine("|  3. Resta Binaria                            |");
                Console.WriteLine("|  4. Salir                                    |");
                Console.WriteLine("|                                              |");
                Console.WriteLine("+----------------------------------------------+");
                Console.WriteLine("|");
                Console.Write("`---------------> Opcion: ");

                if (int.TryParse(Console.ReadLine(), out Opcion))
                {
                    switch (Opcion)
                    {
                        case 1:
                            Console.Clear();
                            binario1.Cargar();
                            binario2.Cargar();
                            return;

                        case 2:
                            Console.Clear();
                            binario1.Cargar();
                            binario2.Cargar();
                            binario1.SumaBinaria(binario1, binario2);
                            return;

                        case 3:
                            Console.Clear();
                            binario1.Cargar();
                            binario2.Cargar();
                            binario1.RestaBinaria(binario1, binario2);
                            return;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Gracias por ejecutar el programa. Hasta luego");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nOpcion no valida. Intente de nuevo ");
                }

                Console.ReadKey();
                Console.Clear();

            } while (Opcion != 4);
        }
    }
}