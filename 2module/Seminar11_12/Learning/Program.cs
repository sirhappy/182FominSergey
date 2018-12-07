using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = 0;
            int d = 0;

            try
            {
                d = a / c;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ex 1");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex 2");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            finally
            {
                Console.WriteLine("finally");
            }
            Console.ReadKey();
        }
    }
}
