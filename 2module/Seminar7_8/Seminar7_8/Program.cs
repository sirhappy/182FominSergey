using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class A
    {
        private int a1;
        protected int a2;
        internal int a3;
        public int a4;
        
        public void GetA()
        {
            Console.WriteLine("A" + a1);
        }

        public void GetInfo()
        {
            Console.WriteLine("Class A");
        }

        virtual public void GetInfo2()
        {
            Console.WriteLine("Class A");
        }
    }

    sealed public class B : A
    {
        public void GetA()
        {
            Console.WriteLine("A" + a2);
        }
    }

    /*public class D : B
    {

    }*/

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
        }
    }
}
