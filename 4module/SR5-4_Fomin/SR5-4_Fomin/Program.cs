using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR5_4_Fomin
{

    class FloydTriangle : IEnumerable<string>
    {
        int _k;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="k">размер</param>
        public FloydTriangle(int k)
        {
            _k = k;
        }

        /// <summary>
        ///     Enumerator
        /// </summary>
        /// <returns>triangle</returns>
        public IEnumerator<string> GetEnumerator()
        {
            int q = 0;
            for (int i = 0; i < _k; ++i)
            {
                string s = (++q).ToString();
                for (int j = 1; j < i + 1; ++j)
                    s = s + " " + (++q).ToString();
                yield return s;
            }
        }

        /// <summary>
        ///     Enumerator
        /// </summary>
        /// <returns>GetEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Возвращает с start до end строчки треугольника
        /// </summary>
        /// <param name="start">начало</param>
        /// <param name="end">конец</param>
        /// <returns>строчки</returns>
        public IEnumerable<string> GetNM(int start, int end)
        {
            int q = 1;
            FloydTriangle t = new FloydTriangle(end);
            foreach (var i in t)
            {
                if (q++ < start) continue;
                yield return i;
            }
        }
    }

    class Program
    {
        private const int MaxSize = 1000;

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите k: ");
                int k;
                while (!int.TryParse(Console.ReadLine(), out k) && k < MaxSize)
                    Console.WriteLine("Неверный формат ввода!");
                FloydTriangle triangle = new FloydTriangle(k);
                foreach (var i in triangle)
                    Console.WriteLine(i);

                int start;
                Console.Write("Введите start: ");
                while (!int.TryParse(Console.ReadLine(), out start) && k < MaxSize)
                    Console.WriteLine("Неверный формат ввода!");

                int end;
                Console.Write("Введите end: ");
                while (!int.TryParse(Console.ReadLine(), out end) && k < MaxSize)
                    Console.WriteLine("Неверный формат ввода!");
                
                foreach (var i in triangle.GetNM(start, end))
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("ESC to quit");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
