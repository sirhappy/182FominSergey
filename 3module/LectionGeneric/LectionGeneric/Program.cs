using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectionGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 19367, d = 3923, c = 10049;
            long ans = Pow(c, d, n);
            Console.WriteLine(ans + " " + (char)ans);

            int e = 107, m = 19358;
            Console.WriteLine(Pow(m, e, n));

            n = 19367;
            e = 107;
            long p = 0, q = 0;
            for (int i = 2; i < n; ++i)
                if (n % i == 0)
                {
                    p = i;
                    q = n / i;
                    break;
                }
            long euler = (p - 1) * (q - 1);
            Console.WriteLine(euler);

            Console.WriteLine(107 % 34);

            Console.ReadKey();
        }
        public static long Pow(long a, long x, long p)
        {
            long ans = a;
            for (int i = 1; i < x; ++i)
                ans = ans * a % p;
            return ans;
        }
    }
}
