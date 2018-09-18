/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Задача: написать метод для вычисления площади и длины окружности void Circle(double r)
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
        public static void Circle(double r, out double d, out double s)
        {
            d = 2 * Math.PI * r;
            s = Math.PI * r * r;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Write("input r: ");
                string inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr, out int r))
                {
                    Console.WriteLine("Wrong input");
                }
                Circle(r, out double d, out double s);
                Console.WriteLine($"диаметр = {d.ToString("f3")}, площадь = {s.ToString("f3")}");
                Console.WriteLine("Для выхода нажмите ESC, иначе любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
