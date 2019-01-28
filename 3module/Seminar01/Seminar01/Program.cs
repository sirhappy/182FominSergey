using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar01
{
    class Program
    {
        delegate void AnyDelegateType(int Smth);

        void F(int x) => Console.WriteLine($"Hello, {x}");

        static void Main(string[] args)
        {
            AnyDelegateType del = F;
            del += F;
            del += F;
            del();
        }
    }
}
