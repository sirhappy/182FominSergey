/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Вариант: -
 * Задача: минимум трёх чисел тернарными операторами
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        public static double ReadDouble(out int d, string msg)
        {
            string inputStr;
            do
                {
                Console.Write("Введите a: ");
                inputStr = Console.ReadLine();
            } while (!int.TryParse(inputStr, out d));
            return d;
        }
        static void Main(string[] args)
        {
            do
            {
                string inputStr;
                do
                {
                    Console.Write("Введите b: ");
                    inputStr = Console.ReadLine();
                } while (!int.TryParse(inputStr, out int b));
                do
                {
                    Console.Write("Введите c: ");
                    inputStr = Console.ReadLine();
                } while (!int.TryParse(inputStr, out int c));

                Console.WriteLine("Для выхода нажмите ESC, иначе любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
