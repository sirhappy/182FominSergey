using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace SR3_Fomin_var2
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                int N = -1;
                Console.WriteLine("Введите N: ");
                while (!int.TryParse(Console.ReadLine(), out N) || !(N > 0 && N <= 1000))
                {
                    Console.WriteLine("Число введено неверно!\nВведите N: ");
                }

                List<TestClass> seq = new List<TestClass>();
                for (int i = 0; i < N; ++i)
                {
                    TestClass testClass = new TestClass();
                    testClass.X = rnd.Next(-5, 6);
                    seq.Add(testClass);
                }

                MySequence<TestClass> mySequence = new MySequence<TestClass>(seq);

                Console.WriteLine("Количество локальных минимумов: " + mySequence.CountLocalMinimum());

                if (!mySequence.IsAllEqual)
                {
                    try
                    {
                        int i = 0;
                        while (true)
                        {
                            Console.WriteLine(mySequence[i].X);
                            i += 2;
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Все элементы равны");
                }

                MySequence<TestClass> mySequence2 = null;
                try
                {
                    mySequence2 = new MySequence<TestClass>(null);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    int i = 0;
                    while (true)
                    {
                        Console.WriteLine(mySequence2[i].X);
                        i += 2;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Нажмите ESC для выхода из программы");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
