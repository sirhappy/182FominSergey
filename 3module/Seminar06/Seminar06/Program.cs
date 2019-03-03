using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar06
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            (test as ITest).TestField = 5;
            Console.WriteLine((test as ITest).TestField);
            Console.ReadKey();
        }
    }

    interface ITest
    {
        int TestField { get; set; }
    }

    class Test : ITest
    {
        int ITest.TestField { get; set; }
    }
}
