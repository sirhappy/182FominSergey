using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_username
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
            Console.ReadKey();
        }
    }
}
