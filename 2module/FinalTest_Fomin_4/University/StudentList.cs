/**
 * Программирование
 * Фомин Сергей
 * Вариант 4
**/

using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    public class StudentList
    {
        static Random rnd = new Random();

        /// <summary>
        ///     Вручную заполненные имена и фамилии
        /// </summary>
        static string[] studentNames = { "Петя", "Вася", "Миша", "Максим", "Володя", "Артём", "Саша", "Данил", "Андрей", "Сергей", "Дима", "Марк" };
        static string[] studentSurnames = { "Иванов", "Смирнов", "Кузнецов", "Соколов", "Павлов", "Волков", "Козлов", "Степанов", "Андреев", "Макаров" };
        
        /// <summary>
        ///     Массив студентов
        /// </summary>
        public Student[] student;

        /// <summary>
        ///     Конструктор студентов
        /// </summary>
        /// <param name="n">Количество студентов</param>
        /// <param name="probability">Вероятность создания хорошего студента</param>
        public StudentList(int n, int probability)
        {
            if (!(1 <= probability && probability <= 100)) throw new ArgumentOutOfRangeException("probability", "Вероятность должна быть в диапазоне [1; 100]");
            student = new Student[n];
            for (int i = 0; i < n; ++i)
            {
                int[] marks = new int[3 * n];
                for (int j = 0; j < 3 * n; ++j)
                    marks[j] = rnd.Next(0, 10);

                try
                {
                    if (rnd.Next(100) < probability)
                        student[i] = new GoodStudent(studentNames[rnd.Next(studentNames.Length)],
                                                     studentSurnames[rnd.Next(studentSurnames.Length)],
                                                     rnd.Next(-5, 5 + 1),
                                                     marks,
                                                     GoodStudent.glassesStyles[rnd.Next(GoodStudent.glassesStyles.Length)]);
                    else
                        student[i] = new BadStudent(studentNames[rnd.Next(studentNames.Length)],
                                                    studentSurnames[rnd.Next(studentSurnames.Length)],
                                                    rnd.Next(-5, 5 + 1),
                                                    marks,
                                                    BadStudent.hairStyles[rnd.Next(BadStudent.hairStyles.Length)]);
                }
                catch (Exception ex)
                {
                    // Долгая работа из-за частых ошибок. BadStudent генерируются, но вероятность этого крайне мала.
                    // Console.WriteLine(ex.Message);
                    --i;
                }
            }
        }

        /// <summary>
        ///     Отобразить всех студентов
        /// </summary>
        public void PrintAllStudents()
        {
            foreach (var i in student)
                Console.WriteLine(i);
        }

        /// <summary>
        ///     Отобразить хорошего студента с худшей средней оценкой
        /// </summary>
        public void PrintWorstGoodStudent()
        {
            GoodStudent goodStudent = null;
            foreach (var i in student)
                if (i is GoodStudent)
                    if (goodStudent == null || i.Mean < goodStudent.Mean)
                        goodStudent = (GoodStudent)i;

            Student stud = student[0];
            var s = student.Where(student1 => student1.Rating < stud.Rating).ToList();


            if (goodStudent == null)
                Console.WriteLine("Хороших студентов нет :(");
            else Console.WriteLine(goodStudent + "\nСредняя оценка: " + goodStudent.Mean.ToString("F3"));
        }

        /// <summary>
        ///     Получить информацию о количестве студентов на всех курсах
        /// </summary>
        public void PrintStudentsCourses()
        {
            int[] cnt = new int[4];
            foreach (var i in student)
                ++cnt[i.Course - 1];
            for (int i = 0; i < 4; ++i)
                Console.WriteLine($"На {i + 1} курсе учатся {cnt[i]} студентов");
        }
    }
}

abstract class A
{
    abstract public void func();

}

class B : A
{
    public override void func()
    {
        throw new NotImplementedException();
    }
}