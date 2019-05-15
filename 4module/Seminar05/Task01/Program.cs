using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{

    class A : IEnumerable<string[]>
    {
        public string[] array = { "cow", "cat", "dog", "horse", "unicorn", "leopard" };

        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (var i in array)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            foreach (var i in a)
            {
                Console.WriteLine(a.array);
            }
        }
    }
}
