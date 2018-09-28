// Группа: БПИ182-2
// Студент: Фомин Сергей
// Задача: 7

using System;

namespace Task07
{
    internal class Program
    {
        /// <summary>
        ///     Считыавает вещественное число из консоли
        /// </summary>
        /// <param name="message">Сообщение, выводящееся на экран перед считыванием</param>
        /// <returns>Полученное значение</returns>
        public static double ReadDouble(string message)
        {
            double result;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out result))
                    isCorrect = true;
                else
                    Console.WriteLine("Неверный формат ввода!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        ///     Решает квадратное уравнение в вещественных числах
        /// </summary>
        /// <param name="a">коэффициент при x^2</param>
        /// <param name="b">коэффициент при x</param>
        /// <param name="c">свободный член</param>
        /// <param name="x1">меньший корень уравнения</param>
        /// <param name="x2">больший корень уравнения</param>
        /// <returns>успех нахождения корней</returns>
        public static bool QuadraticEquation(double a, double b, double c, out double x1, out double x2)
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0 || Math.Abs(a) < double.Epsilon && Math.Abs(b) < double.Epsilon)
            {
                x1 = 0;
                x2 = 0;
                return false;
            }

            x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            return true;
        }

        private static void Main(string[] args)
        {
            do
            {
                double a = ReadDouble("Введите a (коэффициент при x^2): ");
                double b = ReadDouble("Введите b (коэффициент при x): ");
                double c = ReadDouble("Введите c (свободный член): ");

                if (QuadraticEquation(a, b, c, out double x1, out double x2))
                    Console.WriteLine($"x1 = {x1:F3}, x2 = {x2:F3}");
                else
                    Console.WriteLine("Корней нет, либо их бесконечно много!");

                Console.WriteLine("Для завершения работы программы нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}