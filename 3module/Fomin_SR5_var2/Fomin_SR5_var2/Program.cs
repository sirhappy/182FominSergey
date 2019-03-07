using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Fomin_SR5_var2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                F fun1 = new F(x => x * x + Math.Sin(x));
                F fun2 = new F(x => x / 2);

                G g = new G(fun2, fun1);
                for (double i = -1; i <= 1; i += 0.1)
                {
                    Console.WriteLine($"x = {i:F4}, g(f(x)) = {g.Function(i):F4};");
                }

                Console.WriteLine("Нажмите ESC для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
