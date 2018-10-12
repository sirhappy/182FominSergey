using System;
using System.Runtime.InteropServices;

namespace Task04
{
    internal class Program
    {
        private const int MinInputValue = 1, MaxInputValue = 40;

        public static int ReadInt(string message = "Введите число: ")
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out result)
                    && (MinInputValue <= result && result <= MaxInputValue))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат ввода");
            } while (!isCorrect);

            return result;
        }

        public static void FillArrayFibonacci(int[] result)
        {
            result[0] = 1;
            result[1] = 1;
            for (int i = 2; i < result.Length; ++i)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
        }

        private static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите n: ");
                int[] array = new int[n];
                FillArrayFibonacci(array);
                Console.WriteLine("Массив, заполненный числами Фибоначчи: ");
                for (int i = array.Length - 1; i >= 0; --i)
                {
                    Console.Write($"{array[i]} ");
                }

                Console.WriteLine();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}