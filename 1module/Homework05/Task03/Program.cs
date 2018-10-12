using System;

namespace Task01
{
    internal class Program
    {
        private const int MinInputValue = 1, MaxInputValue = 100000;

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

        public static void FillArrayProgression(int a, int d, int[] result)
        {
            result[0] = a;
            for (int i = 1; i < result.Length; ++i)
            {
                result[i] = result[i - 1] + d;
            }
        }

        private static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите n: ");
                int a = ReadInt("Введите a: ");
                int d = ReadInt("Введите d: ");
                int[] array = new int[n];
                FillArrayProgression(a, d, array);
                Console.WriteLine("Массив, заполненный арифметической прогрессией: ");
                Console.WriteLine(string.Join(" ", array));
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}