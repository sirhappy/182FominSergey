using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        delegate int Cast(double x);

        static void Main(string[] args)
        {
            Cast c;
            c = delegate (double x) { if ((int)Math.Truncate(x) % 2 == 0) return (int)Math.Truncate(x);
                else return (int)Math.Truncate(x) + 1;
            };
            Cast c2;
            c2 = delegate (double x)
            {
                return (int)Math.Log10(x) + 1;
            };
            Cast d = c;
            d += c2;
            double y = 10.5;
       //     Console.WriteLine(d.GetInvocationList()[0].DynamicInvoke(y));
       //     Console.WriteLine(d.GetInvocationList()[1].DynamicInvoke(y));
            foreach (var i in d.GetInvocationList())
                Console.WriteLine(i.DynamicInvoke(y));
            Console.Read();
        }
    }
}
