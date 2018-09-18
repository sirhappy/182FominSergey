using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        public static int ReadInt(string msg = "Введите инт")
        {
            string inputStr;
            int a;
            do
            {
                Console.Write(msg);
                inputStr = Console.ReadLine();
            } while (!int.TryParse(inputStr, out a) || !(a >= 100 && a <= 999));
            return a;
        }
        static void Main(string[] args)
        {
            do
            {
                int a = ReadInt("Введите трёхзначное число: ");
                Console.WriteLine(a / 100);
                Console.WriteLine(a / 10 % 10);
                Console.WriteLine(a % 10);
                Console.WriteLine("Нажмите ESC для выхода программы. Для повторного запуска - любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
