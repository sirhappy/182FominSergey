using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection
{
    class SomeClass
    {
        public string Field1 = "1";
    }

    class OtherClass : SomeClass
    {
        new public string Field1 = "2";
        public void PrintField1()
        {
            Console.WriteLine(Field1);
            Console.WriteLine(base.Field1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OtherClass other = new OtherClass();
            SomeClass some = other;
            Console.WriteLine(other.Field1);
            Console.WriteLine(some.Field1);
            other.PrintField1();
            Console.ReadLine();
        }
    }
}
