using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{


    class Program
    {
        public static int[] Func(int[] arr)
        {
            return arr.Reverse().ToArray();
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = a.ToArray();
            int[] c = Func(b);

            foreach (var i in a) Console.Write(i + " ");
            Console.WriteLine();
            foreach (var i in b) Console.Write(i + " ");
            Console.WriteLine();
            foreach (var i in c) Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
