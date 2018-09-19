using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(5.0 / 3.0) F " + (5.0 / 3.0).ToString("f"));
            Console.WriteLine("(5.0 / 3.0) F4 " + (5.0 / 3.0).ToString("f4"));
            Console.WriteLine("(5.0 / 3.0) E " + (5.0 / 3.0).ToString("e"));
            Console.WriteLine("(5.0 / 3.0) E5 " + (5.0 / 3.0).ToString("e5"));
            Console.WriteLine("(5.0 / 3.0) G " + (5.0 / 3.0).ToString("g"));
            Console.WriteLine("(5.0 / 3.0) G3 " + (5.0 / 3.0).ToString("g3"));
            Console.WriteLine("(5.0 / 3e10) G3 " + (5.0 / 3e10).ToString("g3"));
            Console.WriteLine("(5.0 / 3e-10) G " + (5.0 / 3e-10).ToString("g"));
            Console.WriteLine("(5.0 / 3e20) G " + (5.0 / 3e20).ToString("g"));
        }
    }
}
