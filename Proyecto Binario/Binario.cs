using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Timers;

namespace Proyecto_Binario
{
    public class Binario
    {

        #region Atributos

        public int Numero { get; set; }
        public List<int> listaBin { get; set; }

        public static int i = 0;


        #endregion

        #region Constructores
        public Binario()
        {
            this.Numero = Numero;
            this.listaBin = new List<int>();
        }

        #endregion

        #region CargarDatos
        public void Cargar()
        {

            bool sw;

            do
            {

                Console.Write($"Ingrese el numero {i + 1}: ");

                if (int.TryParse(Console.ReadLine(), out int numeroIngresado))
                {

                    if (numeroIngresado < 0)
                    {
                        Console.WriteLine("\nEntrada no valida. Ingrese un numero entero positivo.\n");
                        sw = false;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Write($"\nEl numero {numeroIngresado} en binario es: ");
                        Numero = numeroIngresado;
                        sw = true;
                        ConvertirABinario(Numero);
                        i++;

                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada no valida. Ingrese un numero entero.\n");
                    sw = false;
                    Console.ReadKey();
                    Console.Clear();
                }


            } while (!sw);

            if (i > 1)
            i = 0;

        }


        #endregion

        #region ConversionABinario

        public void ConvertirABinario(int Numero)
        {

            if (Numero > 0)
            {
                while (Numero > 0)
                {
                    listaBin.Add(Numero % 2);
                    Numero = Numero / 2;
                }
            }
            else if (Numero == 0)
            {
                listaBin.Add(0);
            }

            listaBin.Reverse();            

            foreach (int Bin in listaBin)
            {
                Console.Write(Bin);
            }
            Console.WriteLine("\n");

        }

        #endregion

        #region SumaBinaria

        public void SumaBinaria(Binario binario1, Binario binario2)
        {
            // Asegurarse que tengan la misma longitud

            int longitud = Math.Max(binario1.listaBin.Count, binario2.listaBin.Count);

            // Rellena con ceros a la izquierda si es necesario

            RellenarConCeros(binario1.listaBin, longitud);
            RellenarConCeros(binario2.listaBin, longitud);

            int acarreo = 0;
            List<int> resultado = new List<int>();

            Console.WriteLine("\nSuma Binaria:\n\n");

            //Imprimir primer numero binario

            Console.Write("    ");
            foreach (int val in binario1.listaBin)
            {
                Console.Write(val);
            }
            Console.Write(" +");
            Console.WriteLine();

            //Imprimir segundo numero binario

            Console.Write("    ");
            foreach (int val in binario2.listaBin)
            {
                Console.Write(val);
            }
            Console.WriteLine();

            // Operacion de suma

            for (int i = longitud - 1; i>=0; i--)
            {
                int suma = binario1.listaBin[i] + binario2.listaBin[i] + acarreo;
                resultado.Insert(0, suma % 2);
                acarreo = suma / 2;
            }

            // Si hay acarreo al final, agrégalo al resultado

            if (acarreo > 0)
            {
                resultado.Insert(0, acarreo % 2);
                acarreo = acarreo / 2;
            }

            // Imprimir linea de suma

            Console.Write("   ");
            for (int i = 0; i < resultado.Count; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            // Imprimir resultado de suma

            Console.Write("   ");
            foreach (int val in resultado)
            {
                Console.Write(val);
            }
            Console.WriteLine();
        }

        private static void RellenarConCeros(List<int> lista, int longitudObjetivo)
        {
            while (lista.Count < longitudObjetivo)
            {
                lista.Insert(0, 0);
            }
        }



        #endregion

        #region RestaBinaria

        public void RestaBinaria(Binario binario1, Binario binario2)
        {
            // Asegurarse que tengan la misma longitud

            int longitud = Math.Max(binario1.listaBin.Count, binario2.listaBin.Count);

            // Rellena con ceros a la izquierda si es necesario

            RellenarConCeros(binario1.listaBin, longitud);
            RellenarConCeros(binario2.listaBin, longitud);

            // Verificar si el primer numero ingresado es menor que el segundo

            bool sw = false;

            for (int i = 0; i < longitud; i++)
            {
                if (binario1.listaBin[i] < binario2.listaBin[i])
                {
                    sw = true;
                    break;
                }
                else if (binario1.listaBin[i] > binario2.listaBin[i])
                {
                    sw = false;
                    break;
                }
            }

            // Si el numero actual es menor, intercambiar los numeros

            if (sw)
            {
                List<int> aux = listaBin;
                listaBin = binario2.listaBin;
                binario2.listaBin = aux;
            }

            Console.WriteLine("\nResta Binaria: \n\n");

            // Imprimir el numero 1

            Console.Write("   ");
            foreach (int val in binario1.listaBin)
            {
                Console.Write(val);
            }
            Console.Write(" -");
            Console.WriteLine();

            // Imprimir el numero 2

            Console.Write("   ");
            foreach (int val in binario2.listaBin)
            {
                Console.Write(val);
            }
            Console.WriteLine();

            // Linea de separacion


            Console.Write("   ");
            for (int i = 0; i < longitud; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            // Calcular el complemento A2 del numero 2

            List<int> compA2 = new List<int>();
            
            foreach (int val in binario2.listaBin)
            {
                compA2.Add(val == 0 ? 1 : 0);
            }

            // Imprimir numero 2 y su complemento A2

            Console.WriteLine("\nPasos para efectuar la resta por metodo del complemento A2:\n");

            Console.WriteLine("\n1) Se calcula el complemento A2 del segundo numero (se cambian 0 por 1 y viceversa)");

            Console.Write("\n\nNumero 2: ");

            foreach (int val in binario2.listaBin)
            {
                Console.Write(val);
            }
            Console.WriteLine("\n");

            Console.Write("Complemento A2 del numero 2: ");

            for (int i = 0; i < longitud - compA2.Count; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(string.Join("", compA2));
            Console.WriteLine("\n");

            // Sumar 1 al complemento A2

            int acarreo = 1;

            List<int> compA2Sumado = new List<int>();

            for (int i = longitud - 1;  i >= 0; i--)
            {
                int suma = compA2[i] + acarreo;
                compA2Sumado.Add(suma % 2);
                acarreo = suma >= 2 ? 1 : 0;
            }

            compA2Sumado.Reverse();

            Console.WriteLine("2) Se le suma 1 al complemento A2 del segundo numero\n");

            Console.WriteLine();

            Console.Write("   ");
            foreach (int val in compA2)
            {
                Console.Write(val);
            }
            Console.Write(" +");
            Console.WriteLine();

            // Imprimir el "1" alineado horizontalmente

            Console.Write("   ");
            for (int i = 0; i < longitud - 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("1");

            // Linea de suma

            Console.Write("   ");
            for (int i = 0; i < longitud; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            // Resultado de suma de complemento A2 + 1

            Console.Write("   ");
            for (int i = 0; i < longitud - compA2Sumado.Count; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(string.Join("", compA2Sumado));
            Console.WriteLine();

            Console.WriteLine("\n3) Suma del numero binario 1 y el complemento A2 + 1 para obtener el resultado final de la resta, descartando el acarreo final\n\n");

            // Imprimir el primer numero binario

            Console.Write("   ");
            foreach (int val in listaBin)
            {
                Console.Write(val);
            }
            Console.Write(" +");
            Console.WriteLine();

            // Imprimir el segundo numero binario (complemento A2)

            Console.Write("   ");
            foreach (int val in compA2Sumado)
            {
                Console.Write(val);
            }
            Console.WriteLine();

            // Imprimir la linea de separacion

            Console.Write("   ");
            for (int i = 0; i < longitud; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            // Realizar la suma binaria

            List<int> resultadoResta = new List<int>();
            acarreo = 0;

            for (int i = longitud - 1; i >= 0; i--)
            {
                int suma = binario1.listaBin[i] + compA2Sumado[i] + acarreo;
                resultadoResta.Insert(0, suma % 2);
                acarreo = suma / 2;
            }

            // Si hay acarreo al final, se ignora

            // Imprimir resultado de la resta

            Console.Write("   ");
               foreach (int val in resultadoResta)
               {
               Console.Write(val);
               }
               Console.WriteLine("\n");

        }
        #endregion

    }

}
