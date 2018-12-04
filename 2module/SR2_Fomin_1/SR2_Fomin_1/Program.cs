/** БПИ 182-2 
 * Фомин Сергей
 * Вариант 1
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR2_Fomin_1
{
    class Program
    {
        static int ReadInt(string message, int minValue, int maxValue)
        {
            int result;
            bool isCorrect = false;
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out result) && minValue <= result && result <= maxValue)
                    isCorrect = true;
            } while (!isCorrect);
            return result;
        }

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите количество студентов: ", 1, 100000);

                Student[] students = Student.FillStudentsArray(n);
                Seminarian sem1 = new Seminarian(rnd.Next(1, 100 + 1), rnd.Next(1, 9 + 1));
                Seminarian sem2 = new Seminarian(rnd.Next(1, 100 + 1), rnd.Next(1, 9 + 1));

                int sum = 0;
                for (int i = 0; i < n; ++i)
                {
                    string work = students[i].DoWork(rnd.Next(1, 100 + 1));
                    students[i].Mark = (int)Math.Round((double)(sem1.CheckWork(work) + sem2.CheckWork(work)) / 2);
                    sum += students[i].Mark;
                }

                //foreach (var k in students)
                //    Console.WriteLine(k.ToString());

                Console.WriteLine("average = " + ((double)sum / n).ToString("F1"));

                Console.WriteLine(sem1);
                Console.WriteLine(sem2);

                Console.WriteLine("Нажмите ESC для выхода из программы");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            // На всю остальную красоту не хватило времени...
        }
    }
}
