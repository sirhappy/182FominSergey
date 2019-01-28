using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Library
    {
        delegate int[] First(int x);
        delegate void Second(int[] x);

        int[] GetDigits(int x) => Array.ConvertAll(x.ToString().ToArray(), el => int.Parse(el.ToString()));

        void PrintArray(int[] x) => Array.ForEach(x, Console.Write($"{x} "));
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
