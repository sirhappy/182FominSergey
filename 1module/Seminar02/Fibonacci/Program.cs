using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class Program
    {
        public static int Fib(int n)
        {
            double b = (1 + Math.Sqrt(5)) / 2;
            double u = (Math.Pow(b, n) - Math.Pow(-b, -n)) / (2 * b - 1);
            return (int)Math.Round(u);
        }
        public static void Main(string[] args)
        {
            do
            {
                Console.Write("Input n: ");
                string inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr, out int n))
                {
                    Console.Write("Wrong input");
                    return;
                }
                Console.WriteLine($"fib(n) = {Fib(n)}");
                Console.WriteLine("Для выхода нажмите ESC, иначе любую другую клавишу");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
