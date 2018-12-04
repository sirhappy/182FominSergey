using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Point
    {
        public Circle(double x, double y, double rad)
        {
            X = x;
            Y = y;
            Rad = rad;
        }

        public double Rad { get; protected set; }

        public override double Area { get { return Math.PI * Rad * Rad; } }

        public override double Len { get { return 2 * Math.PI * Rad; } }

        public override void Display() => Console.WriteLine($"[Circle] X = {X:F3}  Y = {Y:F3}  Rad = {Rad:F3}");
        
    }
}
