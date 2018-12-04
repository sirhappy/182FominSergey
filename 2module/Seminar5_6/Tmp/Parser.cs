using System;
using Common;

namespace TASK03H {
    class Complex {
        public double Re { get; }
        public double Im { get; }

        public double Abs => Math.Sqrt(Re + Im);

        // Не совсем то что надо, но коллизий нет
        public double Arg => Math.Atan2(Im, Re);

        public Complex(double re, double im) {
            Re = re;
            Im = im;
        }

        public Complex(Complex other) {
            Re = other.Re;
            Im = other.Im;
        }

        // Implicit conversions
        public static implicit operator Complex(int value) => new Complex(value, 0);
        public static implicit operator Complex(double value) => new Complex(value, 0);

        // Add / Sub
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im);
        public static Complex operator -(Complex a, Complex b) => new Complex(a.Re - b.Re, a.Im - b.Im);

        // Mul / Div
        public static Complex operator *(Complex a, Complex b) {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + b.Re * a.Im);
        }

        public static Complex operator /(Complex a, Complex b) {
            var bottom = b.Re * b.Re + b.Im * b.Im;
            return new Complex((a.Re * b.Re + a.Im * b.Im) / bottom, (b.Re * a.Im - a.Re * b.Im) / bottom);
        }
    }

    class Program {
        static double inf = 2.0;
        static int maxIter = 1024;
        static double left = -1.5;
        static double right = 0.5;
        static double top = 1;
        static double bottom = -1;

        static ConsoleColor[] palette = {
            ConsoleColor.Green,
            ConsoleColor.Black
        };

        static int Mandelbrot(Complex c) {
            var z = new Complex(c);
            for (var i = 0; i < maxIter; i++) {
                if (z.Abs > inf) return i;
                z = z * z + c;
            }
            return maxIter;
        }

        static ConsoleColor GetColor(int iters) {
            var normalized = (double) iters / (maxIter + 1);
            var index = (int) Math.Floor(normalized * palette.Length);
            return palette[index];
        }

        static void Main() {
            do {
                int width;
                do {
                    Console.Clear();
                    width = Parser.Input<int>("Enter canvas width (symbols): ", x => x > 30);
                    Console.WriteLine("Make sure following is displayed on one single line:");
                    Console.WriteLine(new string('=', width));
                    Console.WriteLine("Is it ok? 'Y' to continue");
                } while (Console.ReadKey(true).Key != ConsoleKey.Y);

                var step = (right - left) / width;
                for (var y = top; y > bottom; y -= (step * 2)) {
                    for (var x = left; x < right; x += step) {
                        var iters = Mandelbrot(new Complex(x, y));
                        var color = GetColor(iters);
                        Console.BackgroundColor = color;
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            } while (Misc.HandleExit());
        }
    }
}