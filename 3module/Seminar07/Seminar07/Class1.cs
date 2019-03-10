using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar07
{

    class TestClass : IComparable
    {
        public int X { get; set; }
        public int CompareTo(Object another)
        {
            if (this.X > ((TestClass)another).X) return 1;
            else if (this.X < ((TestClass)another).X) return -1;
            return 0;
        }
    }

    struct TestStruct : IComparable
    {
        public int x;
        public int CompareTo(Object another)
        {
            if (this.x > ((TestStruct)another).x) return 1;
            else if (this.x < ((TestStruct)another).x) return -1;
            return 0;
        }
    }

    public class Task01
    {
        public static Random rnd = new Random();
        private const int N = 10000;
        public static void PrintTime(TimeSpan timesp)
        {
            Console.WriteLine("Struct time");

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timesp.Hours, timesp.Minutes, timesp.Seconds, timesp.Milliseconds / 10);
        }

        public void Main()
        {

        }
    }
}
