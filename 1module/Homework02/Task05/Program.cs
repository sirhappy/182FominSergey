/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: -
 * Задача: трёхзначное число по цифрам в столбик
*/

using System;

namespace Task05
{
    class Program
    {
        public static int ReadInt(string msg = "Введите инт")
        {
            int a;
            do Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out a) || !(a >= 100 && a <= 999));
            return a;
        }

        public static void ToDigit(int a, out int d1, out int d2, out int d3)
        {
            d1 = a / 100;
            d2 = a / 10 % 10;
            d3 = a % 10;
        }

        static void Main(string[] args)
        {
            do
            {
                int a = ReadInt("Введите трёхзначное число: ");
                ToDigit(a, out int d1, out int d2, out int d3);
                Console.WriteLine(d1);
                Console.WriteLine(d2);
                Console.WriteLine(d3);

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
