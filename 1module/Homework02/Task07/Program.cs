/*
 * Группа: БПИ182-2
 * Студент: Фомин Сергей Дмитриевич
 * Дата: 18.09.2018
 * Вариант: -
 * Задача: !(x && y || z)
*/

using System;

namespace Task07
{
    class Program
    {
        public static bool ReadBool(string msg = "Введите 0 или 1: ")
        {
            int a;
            do Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out a) || !(a == 0 || a == 1));
            return a == 1 ? true : false;
        }

        static void Main(string[] args)
        {
            do
            {
                bool x = ReadBool("Введите x: ");
                bool y = ReadBool("Введите y: ");
                bool z = ReadBool("Введите z: ");
                Console.WriteLine($"!(x && y || z) = {!(x && y || z)}");

                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
