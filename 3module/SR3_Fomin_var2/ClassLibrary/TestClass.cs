using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TestClass : IComparable<TestClass>
    {
        public int X { get; set; }

        public int CompareTo(TestClass other)
        {
            return X.CompareTo(other.X);
        }
    }
}
