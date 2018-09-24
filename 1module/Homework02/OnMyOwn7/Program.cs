/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 24.09.2018
 * Вариант: -
 * Задача: целая часть, дробь, sqr, sqrt
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

        //a - целая часть, b - дробная
        public static void IntFrac(double x, out int a, out double b)
        {
            a = (int)x;
            b = x - a;
        }

        //c - квадрат, d - корень
        public static void SqrSqrt(double x, out double c, out double d)
        {
            c = x * x;
            d = Math.Sqrt(x);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            do
            {
                double x = ReadDouble("Введите дробное число: ");
                int a;
                double b, c, d;
                IntFrac(x, out a, out b);
                SqrSqrt(x, out c, out d);
                Console.WriteLine($"Целая часть x = {a}");
                Console.WriteLine($"Дробная часть x = {b.ToString("f3")}");
                Console.WriteLine($"Квадрат x = {c.ToString("f3")}");
                if (Double.IsNaN(d))
                    Console.WriteLine("Корень извлечь невозможно (он комплексный, дальше всё ясно)");
                else
                    Console.WriteLine($"Квадратный корень x = {d.ToString("f3")}");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
