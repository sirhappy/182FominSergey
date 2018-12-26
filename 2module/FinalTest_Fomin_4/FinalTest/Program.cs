/**
 * Программирование
 * Фомин Сергей
 * Вариант 4
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace FinalTest
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                int n = Parser.ReadInt(1, 100, "Введите число студентов: ");
                StudentList studentList = null;
                bool f = false;
                while (!f)
                    try
                    {
                        int probability = rnd.Next(-50, 150 + 1);
                        studentList = new StudentList(n, probability);
                        f = true;
                    }
                    catch (Exception e)
                    {
                        // Если Exception, то попробуем сгенерировать опять
                     //   Console.WriteLine(e.Message);
                     //   continue;
                    }
                studentList.PrintAllStudents();
                Console.WriteLine();
                Console.Write("Хороший студент с наименьшим средним баллом: ");
                studentList.PrintWorstGoodStudent();
                Console.WriteLine();
                studentList.PrintStudentsCourses();
                

                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }
}
