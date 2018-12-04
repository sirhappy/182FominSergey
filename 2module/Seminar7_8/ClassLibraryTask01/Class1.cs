using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTask01
{
    public class A
    {
        public virtual void GetA() => Console.WriteLine("A");
    }

    public class B : A
    {
        public override void GetA() => Console.WriteLine("B");
    }
}
