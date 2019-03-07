using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        public T Compare<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) == 1) return a;
            else return b;
        }

        static void Main(string[] args)
        {

        }
    }

    class Point<T> : IComparable<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public int GetLength()
        {
            dynamic x = X, y = Y;
            return x * x + y * y;
        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
        
    }
}
