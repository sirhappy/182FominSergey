using System;

namespace Task01
{
    internal class Program
    {
        private static int MaxArraySize = 100000;

        public static int ReadInt(string message = null)
        {
            bool isCorrect = false;
            int result;
            do
            {
                Console.WriteLine("Введите " + message + ": ");
                if (int.TryParse(Console.ReadLine(), out result))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный ввод");
            } while (!isCorrect);

            return result;
        }

        private static void Main(string[] args)
        {
            
            do
            {
                var rng = new Random();
                int k = ReadInt("k");
                var array = new char[k];
                for (int i = 0; i < k; ++i) array[i] = (char) (rng.Next(26) + 'A');

                Console.WriteLine(string.Join(" ", array));

                var copiedArray = array;

                Array.Sort(copiedArray);
                Console.WriteLine(string.Join(" ", copiedArray));

                Array.Reverse(copiedArray);
                Console.WriteLine(string.Join(" ", copiedArray));

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}