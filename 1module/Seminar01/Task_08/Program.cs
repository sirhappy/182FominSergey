using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            string inputStr;
            Console.Write("Введите x: ");
            inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out x))
            {
                Console.Write("Это не инт, введите инт: ");
                inputStr = Console.ReadLine();
            }
            Console.Write("Введите y: ");
            inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out y))
            {
                Console.Write("Это не инт, введите инт: ");
                inputStr = Console.ReadLine();
            }
            Console.WriteLine("x - y = " + (x - y));
            Console.WriteLine("x + y = " + (x + y));
            Console.WriteLine("x / y = " + (x / y));
            Console.WriteLine("x % y = " + (x % y));
            Console.WriteLine("x << y = " + (x << y));
            Console.WriteLine("x >> y = " + (x >> y));
        }
    }
}
