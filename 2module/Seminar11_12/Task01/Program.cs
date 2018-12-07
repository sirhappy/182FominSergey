using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{

    class Matrix
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <exception cref="OutOfMemoryException"></exception>
        public static void WriteLine(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < m.GetLength(1); ++j)
                    Console.Write(m[i, j] + " ");
        }

        public static int[,] CreateEMatrix(int k)
        {
         //   if (k <= 0) throw new Ex
            int[,] m = new int[k, k];
            for (int i = 0; i < k; ++i)
                m[i, i] = 1;
            return m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string s = null;
            try
            {
                Console.WriteLine("Введите размер единичной матрицы: ");
                n = int.Parse(s);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Ничего не введено!");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Неверный формат ввода!");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Слишком большое число!");
                Console.WriteLine(ex.Message);
            }

            try
            {
                int[,] m = Matrix.CreateEMatrix(n);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("CreateEMatrix OutOfMemory");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("CreateMatrix Overflow");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
