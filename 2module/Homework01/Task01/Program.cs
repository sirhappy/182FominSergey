using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {

        const int minArrayLength = 1, maxArrayLength = 10;
        const int minRandom = 1, maxRandom = 10;
        public static Random rnd = new Random();

        public static int ReadInt(string message, int minValue, int maxValue)
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out result) && minValue <= result && result <= maxValue))
                    Console.WriteLine("Некорректный ввод");
            } while (!isCorrect);
            return result;
        }

        public static int[,] GenRandomArray(int n, int m)
        {
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    arr[i, j] = rnd.Next(minRandom, maxRandom + 1);
            return arr;
        }

        public static void CountSumMultOfStringInArray(int[,] arr, int k, out int sum, out int mult)
        {
            sum = 0;
            mult = 1;
            for (int i = 0; i < arr.GetLength(1); ++i)
            {
                sum += arr[k, i];
                mult *= arr[k, i];
            }
        } 

        public static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < arr.GetLength(1); ++j)
                    Console.Write(arr[i, j] + " ");
        }

        static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите n: ", minArrayLength, maxArrayLength);
                int m = ReadInt("Введите m: ", minArrayLength, maxArrayLength);
                int[,] arr = GenRandomArray(n, m);
                Console.WriteLine("Полученный массив: ");
                PrintArray(arr);
                int k = ReadInt("Введите k: ", minArrayLength, n) - 1; // Массивы хранятся с нуля
                CountSumMultOfStringInArray(arr, k, out int sum, out int mult);
                Console.WriteLine($"sum = {sum}\nmult = {mult}");

                Console.WriteLine("Press Escape to exit program");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape); 
        }
    }
}
