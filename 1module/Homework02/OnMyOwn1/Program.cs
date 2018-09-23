/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 23.09.2018
 * Вариант: -
 * Задача: Самостоятнельно 1: полином
*/

using System;

namespace OnMyOwn1
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

        //F считает значение полинома
        public static int F(int x)
        {
            int x1 = x;
            int x2 = x * x1;
            int x3 = x * x2;
            int x4 = x * x3;
            return 12 * x4 + 9 * x3 - 3 * x2 + 2 * x1 - 4;
        }

        static void Main(string[] args)
        {
            do
            {
                int x = ReadInt("Введите x: ");
                Console.WriteLine(F(x));

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
