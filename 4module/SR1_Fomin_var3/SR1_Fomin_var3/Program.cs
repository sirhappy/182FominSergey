/*
 * Студент: Фомин Сергей
 * Группа: БПИ182-2
 * Вариант 3
 * 12.04.2019
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StudentLibrary;

namespace SR1_Fomin_var3
{

    class Program
    {
        public static Random rnd = new Random(1514);

        const int NumberOfStudents = 30;
        const int MinHeight = 151;
        const int MaxHeight = 200;
        const int MinMark = 1;
        const int MaxMark = 5;

        static void Main(string[] args)
        {
            Student[] students = new Student[NumberOfStudents];
            for (int i = 0; i < students.Count(); ++i)
            {
                int height = rnd.Next(MinHeight, MaxHeight + 1);
                double mark = rnd.Next(MinMark, MaxMark) + (1 - rnd.NextDouble()); // Так мы сможем получить 5
                students[i] = new Student(height, mark);
            }

            XmlSerializer xs = new XmlSerializer(typeof(Student[]));
            using (FileStream fs = new FileStream("../../../file1.xml", FileMode.Create))
            {
                xs.Serialize(fs, students);
            }

            SoapFormatter sf = new SoapFormatter();
            using (FileStream fs = new FileStream("../../../file2.soap", FileMode.Create))
            {
                sf.Serialize(fs, students);
            }

            foreach(var i in students)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
