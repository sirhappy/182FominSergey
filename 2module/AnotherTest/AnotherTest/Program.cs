using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTest
{
    public class B
    {
        int field;
        protected B() { Console.Write(++field); }
        public B(int x) { field = x; Console.Write(field); }
    }
    public class A : B
    {
        B par;
        public A(int x) : base(x)
        {
            par = new B(); Console.Write(++x);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.ReadLine();
        }
    }
}
