using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection2
{
    class MyBaseClass
    {
        virtual public void Print()
        {
            Console.WriteLine("MyBaseClass");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        public override void Print()
        {
            Console.WriteLine("Derived");
        }
    }

    class MySecondDerivedClass : MyDerivedClass
    {
        override public void Print()
        {
            Console.WriteLine("second");
        }
    }
    class Program
    {
        private const int MaxRandomValue = 50;
        private const int MinRandomValue = 10;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = rnd.Next(MinRandomValue, MaxRandomValue + 1);
            MySecondDerivedClass msdc= new MySecondDerivedClass();
            MyDerivedClass derived = new MyDerivedClass();
            MyBaseClass mybc = msdc;
            mybc.Print();
            Console.ReadLine();
        }
    }
}
