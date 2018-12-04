using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Square : Point
    {
        public Square(double x, double y, double side)
        {
            X = x;
            Y = y;
            Side = side;
        }
        public double Side { get; protected set; }

        public override double Area { get { return Side * Side; } }

        public override double Len { get { return 4 * Side; } }

        public override void Display() => Console.WriteLine($"[Square] X = {X:F3}  Y = {Y:F3}  Side = {Side:F3}");
        
    }
}
