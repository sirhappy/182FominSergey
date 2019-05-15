using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar04
{
    using System;
    using System.Collections;

    public class A : IEnumerable
    {
        private string[] arr = { "раз ромашка ", "два ромашка ", "три ромашка ", "пять ромашка ", "шестьромашка " };

        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    } //end of A
    class Program
    {
        static void Main()
        {
            string[] testArr = { "раз ", "два ", "три " };
            foreach (string str in testArr) // "проходит" по любому массиву
                Console.Write(str);
            A a = new A();
            foreach (string str in a) // ошибка компиляции
                Console.Write(str);
        } // end of Main()
    } // end of Program`
}
