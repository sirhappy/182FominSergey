using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Polygon
    {
        private double _radius;
        private uint _n;

        public Polygon(double radius = 10, uint n = 3)
        {
            _radius = radius;
            _n = n;
        }

        public double Area
        {
            get
            {
                return Perimetr * _radius / 2;
            }
        }

        public double Perimetr
        {
            get
            {
                double a = 2 * _radius / Math.Tan(Math.PI / 2 - Math.PI / _n);
                return _n * a;
            }
        }

        public string PolygonData()
        {
            return $"n = {_n:F3}, r = {_radius:F3}, P = {Perimetr:F3}, S = {Area:F3}";
        }
    }  

    class Program
    {
        static void Main(string[] args)
        {
            List<Polygon> polygons = new List<Polygon>();
            while (true)
            {
                double.TryParse(Console.ReadLine(), out double radius);
                uint.TryParse(Console.ReadLine(), out uint n);
                if (radius == 0 && n == 0)
                    break;
                polygons.Add(new Polygon(radius, n));
                Console.WriteLine(polygons.Last().PolygonData());
            }
            Console.ReadKey();
        }
    }
}
