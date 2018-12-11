using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumericLibrary;

namespace ConsolePair
{
    class Program
    {
        private const int MinValue = -50;
        private const int MaxValue = 50;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = 10;
            Pair[] arr = new Pair[n];
            for (int i = 0; i < n; ++i)
            {
                if (rnd.Next(2) == 0) arr[i] = new Complex(rnd.Next(MinValue, MaxValue + 1), rnd.Next(MinValue, MaxValue + 1));
                else arr[i] = new Rational(rnd.Next(MinValue, MaxValue + 1), rnd.Next(MinValue, MaxValue + 1));
            }
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i]);
            Console.ReadKey();
        }
    }
}
