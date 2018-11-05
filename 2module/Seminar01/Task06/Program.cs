using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Program
    {

        public static void Swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }

        static void Main(string[] args)
        {
            string[] lines = new string[] { "нуль", "один", "два", "три",
                                            "четыре", "пять", "шесть", "семь",
                                            "восемь", "девять", "десять" };
            for (int i = 1; i < lines.Length; ++i)
                for (int j = lines.Length - 1; j >= i; --j)
                    if (lines[j].Length < lines[j - 1].Length)
                        Swap(ref lines[j], ref lines[j - 1]);
            
            for (int i = 0; i < lines.Length; ++i)
                Console.Write(lines[i] + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
