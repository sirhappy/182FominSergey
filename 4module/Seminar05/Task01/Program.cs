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
            SortedSet<char> chars = new SortedSet<char>();
            Dictionary<char, List<string>> dict = new Dictionary<char, List<string>>();
            foreach (var i in array)
            {

                if (dict[i[0]] == null) dict[i[-0]] = new List<string>();
                dict[i[0]].Add(i);
            }
            
            foreach (var i in dict.Keys)
            {
                if (dict[i] != null)
                    yield return dict[i].ToArray();
            }

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
                foreach (var j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }
    }
}
