using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeComplex
{
    class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public Complex() : this(0, 0) { }

        public Complex(Complex a)
        {
            Re = a.Re;
            Im = a.Im;
        }

        public static implicit operator Complex(double result)
        {
            return new Complex(result, 0);
        }
        
        public static Complex operator +(Complex a, Complex b)
        {
            Complex result = new Complex();
            result.Im = a.Im + b.Im;
            result.Re = a.Re + b.Re;
            return result;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex result = new Complex();
            result.Im = a.Im - b.Im;
            result.Re = a.Re - b.Re;
            return result;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            Complex result = new Complex();
            result.Im = a.Im * b.Im - a.Re * b.Re;
            result.Re = a.Im * b.Re + a.Re * b.Im;
            return result;
        }

        public static Complex operator /(Complex a, Complex b)
        {
            Complex result = new Complex(a * b);
            result.Im /= (b.Im * b.Im + b.Re * b.Re);
            result.Re /= (b.Im * b.Im + b.Re * b.Re);
            return result;
        }

        public override string ToString()
        {
            return $"{Im} + {Re}i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(-5, -17);
            Complex[,] m = { { new Complex(10, 11), new Complex(8, -9), new Complex(0, 1), new Complex(1, -5) },
                             { new Complex(-30, 3), new Complex(1, 11), new Complex(2, -5), z},
                             { new Complex(21, -14), new Complex(-3, -14), new Complex(3, 4), new Complex(-5, -3) },
                             { new Complex(4, 0), z, new Complex(4, -4), new Complex(-3, -5)} };
            int n = 4;
            for (int i = 0; i < n; ++i)
            {
                int[] x = new int[3];
                int indx = 0;
                for (int q = 0; q < n; ++q)
                    if (q != i) x[indx++] = q;

                for (int j = 0; j < n; ++j)
                {
                    int[] y = new int[3];
                    int indy = 0;
                    for (int q = 0; q < n; ++q)
                        if (q != j) x[indy++] = q;

                    Complex ans = m[x[0], y[0]] * m[x[1], y[1]] * m[x[2], y[2]]
                                + m[x[1], y[0]] * m[x[2], y[1]] * m[x[0], y[2]]
                                + m[x[2], y[0]] * m[x[0], y[1]] * m[x[1], y[2]]
                                - m[x[2], y[0]] * m[x[1], y[1]] * m[x[2], y[0]]
                                - m[x[1], y[0]] * m[x[0], y[1]] * m[x[2], y[0]]
                                - m[x[0], y[0]] * m[x[2], y[1]] * m[x[1], y[0]];
                    if (Math.Abs(ans.Im) > Double.Epsilon || Math.Abs(ans.Re) > Double.Epsilon)
                        Console.WriteLine(ans.Im + " " + ans.Re);
                }
            }
            Console.ReadLine();
        }
    }
}
