using System;

namespace Task02
{
    internal class Program
    {
        private const int MinInputValue = 1, MaxInputValue = 1000000;

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

        public static void FillArrayOddNumbers(int basePower, int[] result)
        {
            result[0] = 1;
            for (int i = 1; i < result.Length; ++i)
            {
                result[i] = result[i - 1] + 2;
            }
        }

        private static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите n: ");
                int[] array = new int[n];
                FillArrayOddNumbers(2, array);
                Console.WriteLine("Массив, заполненный нечётными числами: ");
                Console.WriteLine(string.Join(" ", array));
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}