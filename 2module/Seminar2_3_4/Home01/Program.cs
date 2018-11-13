using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home01
{
    class Circle
    {
        private double _r;

        public double Radius
        {
            get { return _r; }
            set { _r = value; }
        }

        public double S
        {
            get { return Math.PI * Math.Pow(_r, 2); }
        }

        public Circle()
        {
            _r = 0;
        }

        public Circle(int r)
        {
            _r = r;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int rmin);
            int.TryParse(Console.ReadLine(), out int rmax);
            double delta;
            do
            {
                double.TryParse(Console.ReadLine(), out delta);
            } while (delta <= 0);
            Circle c = new Circle();
            for (double i = rmin; i <= rmax; i += delta)
            {
                c.Radius = i;
                Console.WriteLine($"R = {c.Radius:F3}, c = {c.S:F3}");
            }
            Console.ReadLine();
        }
    }
}
