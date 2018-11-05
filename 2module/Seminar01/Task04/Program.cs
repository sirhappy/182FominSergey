using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        public static void FillArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    array[i, j] = (i + 1) * (2 * j + 1);
        }

        public static void FillArrayZeroes(int[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1)) return;
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = array.GetLength(0) - 1; j > array.GetLength(0) - 1 - i; --j)
                    array[i, j] = 0;
        }

        static void Main(string[] args)
        {
            uint N, M;
            int[,] ar;
            do
            {
                uint.TryParse(Console.ReadLine(), out N);
                uint.TryParse(Console.ReadLine(), out M);
                ar = new int[N, M];
                FillArray(ar);
                Console.WriteLine(ar.Rank);
                Console.WriteLine(ar.Length);
                FillArrayZeroes(ar);
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < M; ++j)
                        Console.Write($"{ar[i, j],-6}");
                    Console.WriteLine();
                }
                Console.WriteLine("ESC для завершения");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
