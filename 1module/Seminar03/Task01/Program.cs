using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static int GetMark(int x)
        {
            switch (x)
            {
                case int n when n >= 1 && n <= 3:
                    return 2;
                case 4:
                case 5:
                    return 3;
                case 6:
                case 7:
                    return 4;
                case 8:
                case 9:
                case 10:
                    return 5;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int x = 9;
            Console.WriteLine($"mark = {GetMark(x)}");
            Console.ReadKey();
        }
    }
}
