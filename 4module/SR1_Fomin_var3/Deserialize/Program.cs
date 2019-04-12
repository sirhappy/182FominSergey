/*
 * Студент: Фомин Сергей
 * Группа: БПИ182-2
 * Вариант 3
 * 12.04.2019
 */

using StudentLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите M: ");
                int m;
                while (!int.TryParse(Console.ReadLine(), out m))
                    Console.WriteLine("Неправильный формат ввода!");

                SoapFormatter sf = new SoapFormatter();
                Student[] students;
                using (FileStream fs = new FileStream("../../../file2.soap", FileMode.OpenOrCreate))
                {
                    students = (Student[])sf.Deserialize(fs);
                }
                foreach(var i in students)
                {
                    if (i.Height > m)
                    {
                        Console.WriteLine(i);
                    }
                }

                Student[] studentsXml;
                XmlSerializer xs = new XmlSerializer(typeof(Student[]));
                using (FileStream fs = new FileStream("../../../file1.xml", FileMode.OpenOrCreate))
                {
                    studentsXml = (Student[])xs.Deserialize(fs);
                }

                double sum = 0;
                foreach(var i in studentsXml)
                {
                    sum += i.AverageMark;
                }
                Console.WriteLine("Avg: " + (sum / studentsXml.Count()).ToString("F3"));

                Console.WriteLine("Нажмтие ESC для выхода");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
