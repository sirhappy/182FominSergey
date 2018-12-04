using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace Checking
{
    class C : A
    {
        public void GetA()
        {
            Console.WriteLine("A" + a2);
        }

        public void GetInfo()
        {
            Console.WriteLine("Class C");
        }

        public override void GetInfo2()
        {
            Console.WriteLine("Class C");
        }

        public void Wow()
        {
            Console.WriteLine("Wow");
        }
    }

    class E : C
    {
        /*
        public void GetInfo2()
        {
            Console.WriteLine("Class E");
        }
        */
    }

    abstract public class AbstractClass
    {
        int a;
        protected int b;

        public void GetInfo()
        {
            Console.WriteLine("String");
        }

        abstract public void GetInfo2();

    }

    abstract class AbstractClass2 : AbstractClass
    {

    }

    class AbstractClass3 : AbstractClass2
    {
        public override void GetInfo2()
        {
            Console.WriteLine("GetInfo2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            C c = new C();
            A ac = new C();

            a.GetInfo();
            c.GetInfo();
            ac.GetInfo();

            C d2 = (C)ac;
            d2.Wow();

            a.GetInfo2();
            c.GetInfo2();
            ac.GetInfo2();

            AbstractClass abstractClass = new AbstractClass3();
            abstractClass.GetInfo2();

            Console.ReadKey();
        }
    }
}
