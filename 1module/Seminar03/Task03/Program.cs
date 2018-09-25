/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: 
*/

using System;

namespace Task03
{
    class Program
    {

        public static double ReadDouble(string msg = "Введите вещественное число: ")
        {
            double a;
            do Console.Write(msg);
            while (!double.TryParse(Console.ReadLine(), out a));
            return a;
        }

        public static double F(double x) => x * x;

        static void Main(string[] args)
        {
            do
            {
                double a = ReadDouble("Введите A: ");
                double delta = ReadDouble("Введите delta: ");
                double ans = 0;
                double i;
                for (i = 0; i < a - delta; i += delta)
                {
                    double t = delta * ((F(i) + F(i + delta)) / 2);
                    ans += t;
                    Console.WriteLine($"{F(i)} {F(i + delta)} {t} {ans}");
                }
                ans += (a - i) * ((F(i) + F(a)) / 2);
                Console.WriteLine($"{F(i)} {F(a)} {(a - i) * ((F(i) + F(a)) / 2)} {ans}");
                Console.WriteLine(ans);

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
