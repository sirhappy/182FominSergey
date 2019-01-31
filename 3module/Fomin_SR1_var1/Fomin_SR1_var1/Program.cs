using System;

namespace Fomin_SR1_var1
{
    internal class Program
    {
        /// <summary>
        ///     Delegate to Count
        /// </summary>
        /// <param name="monominal">monominal</param>
        /// <returns>count monominal</returns>
        public delegate double Count(Monominal monominal);

        private static void Main(string[] args)
        {
            Random rnd = new Random();
            do
            {
                Monominal[] monominals = new Monominal[8];
                for (int i = 0; i < 8; ++i)
                {
                    monominals[i] = new Monominal(rnd.Next(-20, 20) + rnd.NextDouble(), (uint)rnd.Next(0, 9));
                }

                foreach (Monominal i in monominals)
                {
                    Console.Write(i.ToString() + " + ");
                }

                Console.WriteLine();

                double x = -1000;
                try
                {
                    Console.Write("Введите x: ");
                    x = double.Parse(Console.ReadLine());
                    if (x < -100 || x > 100)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод!");
                }

                Count count = (Monominal m) => Math.Pow(m.A, m.n);

                double ans = 0;
                for (int i = 0; i < 8; ++i)
                {
                    ans += count(monominals[i]);
                }

                Console.WriteLine("Значение многочлена = " + ans.ToString("F3"));

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

    internal class Monominal
    {
        public double A, x;
        public uint n;

        public Monominal()
        {
            A = 0;
            x = 0;
            n = 0;
        }

        public Monominal(double a, uint n)
        {
            A = a;
            this.n = n;
        }

        public override string ToString()
        {
            return $"{A:F3}*x^{n}";
        }
    }
}
