using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point();
            Point[] arr = { new Point { X = 1, Y = 4 }, new Point { X = 1, Y = 3 } };
            Console.WriteLine(arr[0].GetHashCode());
            Point[] check = arr.Distinct().ToArray();
            Console.WriteLine(check.Count());
            Console.ReadKey();
        }
    }
}
