using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        public static void FillArrayPascal(int[][] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.WriteLine(i);
                arr[i] = new int[i + 1];
                arr[i][0] = 1;
                for (int j = 1; j < i; ++j)
                    arr[i][j] = arr[i - 1][j - 1] + arr[i - 1][j];
                arr[i][i] = 1;
            }
        }

        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int n);
            int[][] arr = new int[n][];
            FillArrayPascal(arr);
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr[i].Length; ++j)
                    Console.Write(arr[i][j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
