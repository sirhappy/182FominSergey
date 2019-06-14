using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Zoo_ClassLibrary;

namespace Task1_ZooProgram1
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Mammal("Murka", true, 2);
            animal.OnSound += delegate { Console.WriteLine("Mamal"); };
            Console.WriteLine(animal);

            IEnumerable<int> collection = new int[] { 1, 2, 3 };
            Console.ReadKey();
        }
    }
}
