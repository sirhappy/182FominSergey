using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            string inputStr;
            Console.Write("Введите a: ");
            inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out a))
            {
                Console.Write("Это не инт, введите инт: ");
                inputStr = Console.ReadLine();
            }
            Console.Write("Введите b: ");
            inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out b))
            {
                Console.Write("Это не инт, введите инт: ");
                inputStr = Console.ReadLine();
            }
            Console.Write("Введите c: ");
            inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out c))
            {
                Console.Write("Это не инт, введите инт: ");
                inputStr = Console.ReadLine();
            }
            int t;
            if (a > b)
            {
                t = a;
                a = b;
                b = t;
            }
            if (b > c)
            {
                t = b;
                b = c;
                c = t;
            }
            if (a > b)
            {
                t = a;
                a = b;
                b = t;
            }
            Console.WriteLine($"Sorted: {a} {b} {c}");
        }
    }
}
