using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[3] { 1, 2, 3123132 };
            foreach (byte b in a)
                Console.WriteLine(b.GetType());
            Console.ReadLine();
        }
    }
}
