using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08
{
    class Program
    {

        static Random rnd = new Random();

        public static int[,] CreateMatrix(int n, int m)
        {
            int[,] matr = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    matr[i, j] = rnd.Next(1, 10);
            return matr;
        }

        public static int[,] MatrixMult(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                return new int[0, 0];
            int[,] c = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); ++i)
                for (int j = 0; j < b.GetLength(1); ++j)
                    for (int k = 0; k < a.GetLength(1); ++k)
                        c[i, j] += a[i, k] * b[k, j];
            return c;
        }

        public static string MatrixToString(int[,] m)
        {
            string s = "";
            for (int i = 0; i < m.GetLength(0); ++i)
            {
                for (int j = 0; j < m.GetLength(1); ++j)
                {
                    s += m[i, j].ToString() + " ";
                }
                s += "\n";
            }
            return s;
        }

        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int an);
            int.TryParse(Console.ReadLine(), out int am);
            int.TryParse(Console.ReadLine(), out int bn);
            int.TryParse(Console.ReadLine(), out int bm);
            int[,] a = CreateMatrix(an, am), b = CreateMatrix(bn, bm);
            int[,] c = MatrixMult(a, b);
            Console.WriteLine(MatrixToString(a));
            Console.WriteLine(MatrixToString(b));
            if (c.Length == 0)
                Console.WriteLine("Умножение невозможно");
            else
                Console.WriteLine(MatrixToString(c));
            Console.ReadKey();
        }
    }
}
