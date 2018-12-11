using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericLibrary
{
    abstract public class Pair
    {
        private int _x;
        public int X { get => _x; protected set => _x = value; }
        public int Y { get; protected set; }

        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }
        public abstract Pair Add(Pair b);
        public abstract Pair Sub(Pair b);
        public abstract Pair Mult(Pair b);
        public int PairEqual(Pair b)
        {
            if (X == b.X && Y == b.Y) return 0;
            if (X < b.Y || X == b.X && Y < b.Y) return -1;
            return 1;
        }

        public override string ToString()
        {
            return $"X = {X}; Y = {Y}";
        }
    }

    public class Complex : Pair
    {
        public Complex(int x, int y) : base(x, y)
        {
        }

        public override Pair Add(Pair b)
        {
            return new Complex(X + b.X, Y + b.Y);
        }

        public override Pair Mult(Pair b)
        {
            return new Complex(X * b.X - Y * b.Y, X * b.Y + Y * b.X);
        }

        public override Pair Sub(Pair b)
        {
            return new Complex(X - b.X, Y - b.Y);
        }

        public override string ToString()
        {
            return $"{X} + {Y}i";
        }
    }

    public class Rational : Pair
    {
        public Rational(int x, int y) : base(x, y)
        {
        }

        public override Pair Add(Pair b)
        {
            return new Rational(X * b.Y + Y * b.X, Y * b.Y);
        }

        public override Pair Mult(Pair b)
        {
            return new Rational(X * b.X, Y * b.Y);
        }

        public override Pair Sub(Pair b)
        {
            return new Rational(X * b.Y - Y * b.X, Y * b.Y);
        }

        public Rational Reduce(Rational b)
        {
            int gcd = 1, tx = b.X, ty = b.Y;
            while (b.X != 0 && b.Y != 0)
            {
                if (b.X > b.Y)
                    b.X %= b.Y;
                else
                    b.Y %= b.X;
            }
            gcd = Math.Max(b.X, b.Y);
            return new Rational(tx / gcd, ty / gcd);
        }

        public override string ToString()
        {
            return $"{X} / {Y}";
        }
    }
}
