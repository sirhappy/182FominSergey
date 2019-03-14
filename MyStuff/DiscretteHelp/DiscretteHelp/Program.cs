using System;
using System.Drawing;

namespace DiscretteHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = new Point[] { new Point(4, 5), new Point(5, 8), new Point(7, 5), new Point(0, 5), new Point(9, 8), new Point(8, 1) };
            for (int i = 0; i < points.Length; ++i, Console.WriteLine())
                for (int j = 0; j < points.Length; ++j)
                {
                    Console.Write($"{Math.Abs(points[i].X - points[j].X) + Math.Abs(points[i].Y - points[j].Y)} ");
                }
            Console.ReadKey();
        }
    }
}
