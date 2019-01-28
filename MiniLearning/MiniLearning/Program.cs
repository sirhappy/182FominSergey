using System;

namespace MiniLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            counter.OnCount += handler1.Message;
            counter.OnCount += handler2.Message;
        
            counter.Count();

            Console.ReadKey();
        }
    }

    class Counter
    {

        public delegate void MethodContainer();
        public event MethodContainer OnCount;

        public void Count()
        {
            for (int i = 0; i < 100; ++i)
            {
                if (i == 71)
                    OnCount?.Invoke();
            }
        }    
    }

    class Handler1
    {
        public void Message()
        {
            Console.WriteLine("Пора действовать, ведь уже 71!");
        }
    }

    class Handler2
    {
        public void Message()
        {
            Console.WriteLine("Точно, уже 71!");
        }
    }
}
