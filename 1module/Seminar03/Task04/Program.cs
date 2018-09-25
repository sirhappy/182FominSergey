/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: 
*/

using System;

namespace Task04
{
    class Program
    {


        static void Main(string[] args)
        {
            do
            {
                double s = 0, prev = -1;
                for (long n = 1; s != prev; ++n)
                {
                    prev = s;
                    s += 1d / (n * (n + 1) * (n + 2));
                }
                Console.WriteLine($"double = {s:F20}");

                float f = 0, fprev = -1;
                for (long n = 1; f != fprev; ++n)
                {
                    fprev = f;
                    f += 1f / (n * (n + 1) * (n + 2));
                }
                Console.WriteLine($" float = {f:F20}");

                decimal d = 0m, dprev = -1m;
                for (decimal n = 1m; d != dprev; ++n)
                {
                    dprev = d;
                    d += 1m / (n * (n + 1) * (n + 2));
                    if (n % 1000000m == 0) Console.WriteLine($" decimal = {d}");
                }
                Console.WriteLine($" decimal = {f:F20}");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
