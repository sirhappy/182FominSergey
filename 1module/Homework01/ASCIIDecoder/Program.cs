using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;

            Console.Write("Введите код символа (от 32 до 127): "); // считываем x (код символа)
            string inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out x) || x < 32 || x > 127)
            {
                Console.Write("Введено неверное значение. Пожалуйста, введите код символа от 32 до 127: ");
                inputStr = Console.ReadLine();
            }

            char c = (char)x;
            Console.WriteLine($"Коду {x} соответствует символ {c}");
            Console.ReadKey();
        }
    }
}
