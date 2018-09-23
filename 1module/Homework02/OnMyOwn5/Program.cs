/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: 
*/

using System;

namespace OnMyOwn5
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

        static void Main(string[] args)
        {
            do
            {
                double a = ReadDouble("Введите первую сторону треугольника: ");
                double b = ReadDouble("Введите вторую сторону треугольника: ");
                double c = ReadDouble("Введите третью сторону треугольника: ");
                double x = Math.Min(a, Math.Min(b, c)); //самый маленький
                double y = Math.Max(Math.Max(Math.Min(a, b), Math.Min(a, c)), Math.Min(b, c)); // средний
                double z = Math.Max(a, Math.Max(b, c)); // большой
                Console.WriteLine(x + y > z ? "Треугольник существует" : "Треугольника не существует");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
