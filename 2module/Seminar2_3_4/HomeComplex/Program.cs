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
            for (int i = -10; i <= 10; ++i)
                for (int j = -10; j <= 10; ++j)
                {
                    Complex c = new Complex(i, j);
                    Console.WriteLine(c);
                }
            Console.ReadLine();
        }
    }
}
