using System;

class Program
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Ro
        {
            get
            {
                //#TODO1: реализовать свойство
                return Math.Sqrt(X * X + Y * Y);
            }
        }
        public double Fi
        {
            get
            {
                //#TODO2: реализовать свойство
                if (X > 0 && Y >= 0) return Math.Atan(Y / X);
                else if (X > 0 && Y < 0) return Math.Atan(Y / X) + 2 * Math.PI;
                else if (X < 0) return Math.Atan(Y / X) + Math.PI;
                else if (Y > 0) return Math.PI / 2;
                else if (Y < 0) return 3 * Math.PI / 2;
                else return 0;
            }
        }

        public Point(double x, double y) { X = x; Y = y; }
        public Point() : this(0, 0) { } // конструктор умолчания
                                        
        public string PointData
        {
            get
            {
                string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
                return string.Format(maket, X, Y, Ro, Fi);
            }
        }

        public override string ToString()
        {
            return $"X = {X:F2} Y = {Y:F2} Ro = {Ro:F2} Fi = {Fi:F2}";
        }
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }

    static void Main()
    {
        Point a, b, c;
        a = new Point(3, 4); Console.WriteLine(a.PointData);
        b = new Point(0, 3); Console.WriteLine(b.PointData);
        c = new Point();
        double x = 0, y = 0;
        do
        {
            Console.Write("x = ");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("y = ");
            double.TryParse(Console.ReadLine(), out y);
            c.X = x; c.Y = y;
        } while (x == 0 && y == 0);
        Point[] m = new Point[3];
        m[0] = a;
        m[1] = b;
        m[2] = c;
        if (a.Ro > b.Ro) Swap(ref a, ref b);
        if (b.Ro > c.Ro) Swap(ref b, ref c);
        if (a.Ro > b.Ro) Swap(ref a, ref b);
        Console.WriteLine($"{a}\n{b}\n{c}");
        Console.ReadLine();
    }
}
