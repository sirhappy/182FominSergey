using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Point
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }

        public virtual void Display() => Console.WriteLine($"[Point] X = {X:F3}  Y = {Y:F3}");

        public virtual double Area => 0;

        public virtual double Len => 0;
    }
}
