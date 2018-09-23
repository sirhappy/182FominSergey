/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: 
 * Задача: 
*/

using System;

namespace OnMyOwn4
{
    class Program
    {
        public static int Read4DigitInt(string msg = "Введите целое число: ")
        {
            int a;
            do Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out a) || !(a >= 1000 && a <= 9999));
            return a;
        }

        //"переворачиваем" четырёхзначное число. String для того, чтобы оставались ведущие нули
        public static string ReverseDigits(int x)
        {
            string d1 = (x / 1000).ToString();
            string d2 = (x / 100 % 10).ToString();
            string d3 = (x / 10 % 10).ToString();
            string d4 = (x % 10).ToString();
            return d4 + d3 + d2 + d1;
        }

        static void Main(string[] args)
        {
            do
            {
                int x = Read4DigitInt("Введите четырёхзначное число: ");
                Console.WriteLine(ReverseDigits(x));

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
