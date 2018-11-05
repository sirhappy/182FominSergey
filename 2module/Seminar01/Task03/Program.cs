using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][][] matr = new char[3][][];

            matr[0] = new char[3][];
            matr[0][0] = new char[2] { 'a', 'b' };
            matr[0][1] = new char[3] { 'c', 'd', 'e' };
            matr[0][2] = new char[4] { 'f', 'g', 'h', 'i' };

            matr[1] = new char[2][];
            matr[1][0] = new char[2] { 'j', 'k' };
            matr[1][1] = new char[3] { 'l', 'm', 'n' };

            matr[2] = new char[1][];
            matr[2][0] = new char[4] { 'o', 'p', 'q', 'r' };

            char[][][] c =
            {
                new char[][]
                {
                    new char[] { 'a', 'b' },
                    new char[] { 'c', 'd', 'e' },
                    new char[] { 'f', 'g', 'h', 'i' },
                },

                new char[][]
                {
                    new char[] { 'j', 'k' },
                    new char[] { 'l', 'm', 'n' },
                },

                new char[][]
                {
                    new char[] { 'o', 'p', 'q', 'r' },
                },
            };

            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                Console.WriteLine("|");
                for (int j = 0; j < matr[i].GetLength(0); ++j)
                {
                    Console.Write("||-");
                    for (int k = 0; k < matr[i][j].GetLength(0); ++k)
                    {
                        Console.Write(matr[i][j][k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("|");
            }

            foreach (char[][] i in matr)
            {
                foreach (char[] j in i)
                {
                    foreach (char k in j)
                    {
                        Console.Write(k + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
