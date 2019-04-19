using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class myComplex
    {
        public double re, im;
        public myComplex(double xre, double xim)
        { re = xre; im = xim; }
        public static myComplex operator --(myComplex mc)
        { mc.re--; mc.im--; return mc; }
        public static myComplex operator ++(myComplex mc)
        { mc.re++; mc.im++; return mc; }

        public static myComplex operator +(myComplex mc1, myComplex mc2)
        {
            return new myComplex(mc1.re + mc2.re, mc1.im + mc2.im);
        }
        public static myComplex operator -(myComplex mc1, myComplex mc2)
        {
            return new myComplex(mc1.re - mc2.re, mc1.im - mc2.im);
        }

        public static myComplex operator *(myComplex mc1, myComplex mc2)
        {
            double a = mc1.re;
            double b = mc1.im;
            double c = mc2.re;
            double d = mc2.im;
            return new myComplex(a * c - b * d, a * d + b * c);
        }

        public static myComplex operator /(myComplex mc1, myComplex mc2)
        {
            double a = mc1.re;
            double b = mc1.im;
            double c = mc2.re;
            double d = mc2.im;
            return new myComplex((a * c + b * d) / (c * c + d * d),
                                 (b * c - a * d) / (c * c + d * d));
        }


        public double Mod() { return Math.Abs(re * re + im * im); }
        static public bool operator true(myComplex f)
        {
            if (f.Mod() > 1.0) return true;
            else return false;
        }
        static public bool operator false(myComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            else return false;
        }
    }
    class Program
    {
        static void Display(myComplex cs)
        {
            Console.WriteLine("real=" + cs.re + ", image=" + cs.im);
        }
        static void Main()
        {
            myComplex c1 = new myComplex(4, 3.3);
            Console.WriteLine("Модуль исходного комплексного числа = " + c1.Mod());
            while (c1)
            {
                Console.Write("c1 => "); Display(c1);
                c1--;
            }
            Console.WriteLine("Модуль полученного числа = " + c1.Mod());
            Console.WriteLine("Число принадлежит кругу с радиусом 1.");
            myComplex c2 = new myComplex(2, 1.4);
            Console.WriteLine("Сложение: ");
            Display(c1 + c2);
            Console.WriteLine("Вычитание: ");
            Display(c1 - c2);
            Console.WriteLine("Умножение: ");
            Display(c1 * c2);
            Console.WriteLine("Деление: ");
            Display(c1 / c2);
            Console.ReadKey();

            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();

        }
    }
}
