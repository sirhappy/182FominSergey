using System;
using System.Threading;

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


            int cntZ = 0, cntX = 0;

            SecondDelayer secondDelayer = new SecondDelayer();
            Stats stats = new Stats();

            secondDelayer.OnSecond += stats.ShowStats;

            Thread thread = new Thread(secondDelayer.Timer);
            thread.Start();

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Z) ++stats.cntZ;
                if (key == ConsoleKey.X) ++stats.cntX;
                if (key == ConsoleKey.Escape) break;
            }

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

    class SecondDelayer
    {
        public delegate void MethodContainer();
        public event MethodContainer OnSecond;

        public void Timer()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                OnSecond();
            }
        }
    }

    class Stats
    {
        public int cntZ { get; set; } = 0;
        public int cntX { get; set; } = 0;

        private int allZ = 0, allX = 0;

        public void ShowStats()
        {
            int bpm = (cntZ + cntX) * 60 / 2;
            int cpm = cntZ + cntX;
            Console.WriteLine($"BPM: {bpm}\tCPM: {cpm}\tZ: {cntZ}\tX: {cntX}");
            allZ += cntZ;
            allX += cntX;
            cntZ = 0;
            cntX = 0;
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
