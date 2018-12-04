using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    class Program
    {
        class C
        {
            int x;
            public int X
            {
                set
                {
                    x = value;
                    Console.Write(X);
                }
                get
                {
                    if (x > 20) return x;
                    return X = x + 1;
                }
            }
        }

        static void Main(string[] args)
        {
            int[][] arr2 = { new int[] { 1, 2, 3 }, new int[] { 1, 2 } };
            C c = new C();
            int[] a = { 1, 2, 3, 4, 5, 6 };
            Array.Clear(a, 1, 3);
            Console.WriteLine(a.Rank + " " + a.Length);
            c.X = 19;
            Console.ReadKey();
        }
    }
}
