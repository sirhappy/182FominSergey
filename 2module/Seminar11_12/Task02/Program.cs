using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class GeomProgr
    {

        public static int objectNumber;

        private double _b, _q;

        public GeomProgr(int b, int q)
        {
            B = b;
            Q = q;
            ++objectNumber;
        }

        public GeomProgr() : this(1, 1) { }

        public double B
        {
            get => _b;
            set
            {
                if (value == 0) throw new ArgumentException("Первый член прогрессии не может равняться нулю!");
                _b = value;
            }
        }

        public double Q
        {
            get => _q;
            set
            {
                if (value == 0) throw new ArgumentException("Знаменатель прогрессии не может равняться нулю!");
                _q = value;
            }
        }

        public double this[int i]
        {
            get
            {
                if (i <= 0) throw new ArgumentException("Индекс должен начинаться с единицы!");
                double result = Q * Math.Pow(B, i - 1);
                if (double.IsInfinity(result) || double.IsNaN(result))
                    throw new OverflowException("Для заданного i последовательность too big");
                return result;
            }
        }

        public double GetSum(int k)
        {
            if (k <= 0) throw new ArgumentException("Индекс должен начинаться с единицы!");

            if (_q == 1) return k * _b;
            double result = B * (Math.Pow(Q, k - 1) - 1) / (Q - 1);
            if (double.IsInfinity(result) || double.IsNaN(result))
                throw new OverflowException("Для заданного i последовательность too big");
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GeomProgr g = new GeomProgr();
            while (true)
            {
                Console.WriteLine("Введите номер члена: ");
                try
                {
                    int n = int.Parse(Console.ReadLine());

                }
            }
        }
    }
}
