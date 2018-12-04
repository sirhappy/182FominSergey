using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace Task02
{
    class Program
    {
        static Random rnd = new Random();

        public static double rndNext { get { return rnd.Next(10, 100) + rnd.NextDouble(); } }

        static Point[] FigArray()
        {
            int circlesCount = rnd.Next(0, 11);
            int squaresCount = rnd.Next(0, 11);
            Point[] figures = new Point[circlesCount + squaresCount];

            for (int i = 0; i < circlesCount; ++i)
                figures[i] = new Circle(rndNext, rndNext, rndNext);
            for (int i = 0; i < squaresCount; ++i)
                figures[circlesCount + i] = new Square(rndNext, rndNext, rndNext);
            return figures;
        }

        static void Main(string[] args)
        {
            int circlesCount = 0, squaresCount = 0;
            Point[] figures = FigArray();

            for (int i = 0; i < figures.Length; ++i)
                if (figures[i] is Circle) ++circlesCount;
                else ++squaresCount;
            Console.WriteLine($"Всего {circlesCount + squaresCount} фигур, из них" +
                $" {circlesCount} - круги и {squaresCount} - квадраты");

            double sumArea = 0, sumLen = 0;
            foreach (var k in figures)
            {
                sumArea += k.Area;
                sumLen += k.Len;
            }
            Console.WriteLine($"Средняя площадь = {sumArea / figures.Length}");
            Console.WriteLine($"Средний периметр = {sumLen / figures.Length}");

            Array.Sort(figures, (a, b) => a.Area.CompareTo(b.Area));
            foreach(var k in figures)
            {
                k.Display();
            }

            Console.ReadKey();
        }
    }
}
