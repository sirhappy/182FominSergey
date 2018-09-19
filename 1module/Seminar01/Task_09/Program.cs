using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_09
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            string inputStr;
            Console.Write("Введите x: ");
            inputStr = Console.ReadLine();
            while (!double.TryParse(inputStr, out x))
            {
                Console.Write("Это не double, введите double: ");
                inputStr = Console.ReadLine();
            }
            Console.Write("Введите y: ");
            inputStr = Console.ReadLine();
            while (!double.TryParse(inputStr, out y))
            {
                Console.Write("Это не double, введите double: ");
                inputStr = Console.ReadLine();
            }
            Console.WriteLine("Сумма дробных частей: " + ((x - (int)x) + y - (int)y).ToString("F10"));
        }
    }
}
