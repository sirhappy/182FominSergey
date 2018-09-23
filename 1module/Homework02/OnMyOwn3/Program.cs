/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 23.09.2018
 * Вариант: -
 * Задача: Найти корни квадратного уравнения
*/

using System;

namespace OnMyOwn3
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
                double a = ReadDouble("Введите A: ");
                double b = ReadDouble("Введите B: ");
                double c = ReadDouble("Введите C: ");
                double d = Math.Sqrt(b * b - 4 * a * c);
                Console.WriteLine(
                a == 0 ?
                    b == 0 ?
                        c == 0 ?
                            "Корней бесконечно много!"
                        :
                            "Корней нет! Вообще никаких нет!"
                    :
                      $"Корень = {(-c / b).ToString("f3")}"
                : b * b < 4 * a * c ?
                    "Тут получаются комплексные корни. Возможность их нахождения есть только в преимум версии." +
                    "Для её получения свяжитесь с Нами по почте edu.sdfomin@ya.ru"
                    :
                        $"x1 = {((b + d) / (2 * a)).ToString("f3")}; x2 = {((-b + d) / (2 * a)).ToString("f3")}"
                );

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
