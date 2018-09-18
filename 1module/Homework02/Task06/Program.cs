/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: -
 * Задача: Круг R = 10. Точка внутри него или нет?
*/

using System;

namespace Task06
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

        static void Main(string[] args)
        {
            do
            {
                int x = ReadInt("Введите координату x: ");
                int y = ReadInt("Введите координату y: ");
                int r = 10, d = x * x + y * y;
                if (d < r * r)
                    Console.WriteLine("Точка лежит внутри круга");
                else if (d == r * r)
                    Console.WriteLine("Точка лежит на границе круга");
                else
                    Console.WriteLine("Точка лежит за пределами круга");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
