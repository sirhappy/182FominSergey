using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            double u, r, i, p;

            Console.Write("Введите значение напряжения: "); // считываем u
            string inputStr = Console.ReadLine();
            while (!double.TryParse(inputStr, out u) || u < 0)
            {
                Console.Write("Ввод неверный. Попробуйте ещё раз: ");
                inputStr = Console.ReadLine();
            }

            Console.Write("Введите значение сопротивления: "); // считываем r
            inputStr = Console.ReadLine();
            while (!double.TryParse(inputStr, out r) || r <= 0)
            {
                Console.Write("Ввод неверный. Попробуйте ещё раз: ");
                inputStr = Console.ReadLine();
            }

            i = u / r;
            p = u * u / r;
            Console.WriteLine($"Сила тока = {i.ToString("f3")}\nПотребляемая мощность = {p.ToString("f3")}");
            Console.ReadKey();
        }
    }
}
