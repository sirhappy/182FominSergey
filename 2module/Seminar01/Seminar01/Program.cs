using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matr = new int[3, 4];
            Random rnd = new Random();
            for (int i = 0; i < matr.GetLength(0); ++i)
                for (int j = 0; j < matr.GetLength(1); ++j)
                    matr[i, j] = rnd.Next();
            Console.WriteLine(matr.Rank);
            Console.WriteLine(matr.Length);
            Console.WriteLine(matr.GetLength(0));
            Console.WriteLine(matr.GetLength(1));
            Console.WriteLine(matr.IsFixedSize);
            /*
            foreach(var x in matr)
            {
                Console.WriteLine(x);
            }
            */
            for(int i = 0; i < matr.GetLength(0); ++i)
            {
                for (int j = 0; j < matr.GetLength(1); ++j)
                    Console.Write($"{matr[i, j]} ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
