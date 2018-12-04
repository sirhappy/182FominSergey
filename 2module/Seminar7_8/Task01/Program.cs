using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryTask01;

namespace Task01
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            A[] array = new A[10];
            for (int i = 0; i < array.Length; ++i)
                if (rnd.Next(0, 2) == 1) array[i] = new A();
                else array[i] = new B();

            foreach (var i in array)
                i.GetA();
            Console.WriteLine();

            foreach (var i in array)
                if (i is B)
                    i.GetA();
            Console.WriteLine();
            
            foreach (var i in array)
                if (!(i is B))
                    i.GetA();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
