/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: Переставить цифры трёхзначного числа в порядке убывания
*/

using System;

namespace OnMyOwn2
{
    class Program
    {
        //считываем трёхзначное число
        public static int Read3DigitInt(string msg = "Введите целое число: ")
        {
            int a;
            do Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out a) || !(a >= 100 && a <= 999));
            return a;
        }

        //меняем местами 2 числа
        public static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        //переставляем цифры в числе в порядке убывания
        public static int SortDigits(int p)
        {
            int d1 = p / 100;
            int d2 = p / 10 % 10;
            int d3 = p % 10;
            if (d1 < d2) Swap(ref d1, ref d2);
            if (d2 < d3) Swap(ref d2, ref d3);
            if (d1 < d2) Swap(ref d1, ref d2);
            return d1 * 100 + d2 * 10 + d3;
        }

        static void Main(string[] args)
        {
            do
            {
                int p = Read3DigitInt("Введите трёхзначное число: ");
                Console.WriteLine(SortDigits(p));

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
