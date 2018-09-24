/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: 
*/

using System;

namespace OnMyOwn6
{
    class Program
    {
        public static int ReadInt(string msg = "Введите целое число: ")
        {
            int a;
            do Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out a));
            return a;
        }
        public static double ReadDouble(string msg = "Введите вещественное число: ")
        {
            double a;
            do Console.Write(msg);
            while (!double.TryParse(Console.ReadLine(), out a));
            return a;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                double x = ReadDouble("Введите размер бюджета: ");
                int p = ReadInt("Введите процент, выделенный на компьютерные игры: ");
                Console.WriteLine($"Выделено {(x * p / 100).ToString("C")} на компьютерные игры");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
