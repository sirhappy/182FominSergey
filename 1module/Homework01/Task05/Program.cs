using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            string inputStr;
            do
            {
                Console.Write("Введите длину первого катета: ");
                inputStr = Console.ReadLine();
            } while (!double.TryParse(inputStr, out a) || a <= 0);
            do
            {
                Console.Write("Введите длину второго катета: ");
                inputStr = Console.ReadLine();
            } while (!double.TryParse(inputStr, out b) || b <= 0);
            double ans = Math.Sqrt(a * a + b * b);
            Console.WriteLine($"Гипотенуза: {ans}");
            Console.ReadKey();
        }
    }
}
