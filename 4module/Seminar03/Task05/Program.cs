using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Interval
    {
        public int Left { get; }
        public int Right { get; }
        public Interval(int left, int right)
        {
            if (left >= right) throw new ArgumentException("Отрезок должен быть ненулевой длины!");
            Left = left;
            Right = right;
        }

        public Interval(Interval interval)
        {
            Left = interval.Left;
            Right = interval.Right;
        }

        public int Length()
        {
            return Right - Left + 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
