using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking
{

    abstract class A
    {

    }

    class B : A
    {

    }

    class C : A
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            A[] arr = new A[10];
            arr[0] = new B();
            arr[1] = new C();
            foreach(var i in arr)
            {
                Console.WriteLine(i.GetType());
            }
        }
    }
}
