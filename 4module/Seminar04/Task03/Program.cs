using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Fibonacci
    {
        int s = 1, n = 0;
        public IEnumerable nextMemb(int limit)
        {
            int t;
            for (int i = 0; i < limit; i++)
            {
                t = s + n;
                s = n;
                yield return n = t;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var i in new Fibonacci().nextMemb(10))
                Console.WriteLine(i);
        }
    }
}
