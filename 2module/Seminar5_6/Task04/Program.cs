
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{

    class ArithmeticSequence
    {
        private double _start;
        private double _increment;

        public ArithmeticSequence()
        {
            _start = 0;
            _increment = 1;
        }

        public ArithmeticSequence(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }

        public double this[int index]
        {
            get
            {
                if (index <= 0) throw new IndexOutOfRangeException();
                return _start + _increment * (index - 1);
            }
        }
     
        public override string ToString()
        {
            return $"a[1] = {_start}; d = {_increment}";
        }

        public double GetSum(int n)
        {
            return (this[1] + this[n]) / 2 * n;
        }
    }
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            ArithmeticSequence arithmetic = new ArithmeticSequence(300, 5);
            int N = rnd.Next(5, 16);
            ArithmeticSequence[] array = new ArithmeticSequence[N];
            for (int i = 0; i < N; ++i)
                array[i] = new ArithmeticSequence(rnd.Next(0, 1001), rnd.Next(1, 11));
            int step = rnd.Next(3, 16);
            Console.WriteLine("step = " + step + '\n');
            for (int i = 0; i < N; ++i)
            {
                if (array[i][step] > arithmetic[step])
                {
                    Console.WriteLine($"{i}: {array[i]}");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < N; ++i)
            {
                Console.WriteLine($"{i}: {array[i]} Сумма первых {step} членов: {array[i].GetSum(step)}");
            }
            Console.ReadLine();
        }
    }
}
