/** БПИ 182-2 
 * Фомин Сергей
 * Вариант 1
 * **/

using System;

namespace SR2_Fomin_1
{
    /// <summary>
    ///     Класс студентов
    /// </summary>
    class Student
    {
        static Random rnd = new Random();
        public Student(long id, int testNum)
        {
            Id = id;
            TestNum = testNum;
        }
        public long Id { get; protected set; }
        public int TestNum { get; protected set; }
        public int Mark { get; set; }
        public string DoWork(int length)
        {
            string s = "";
            for (int i = 0; i < length; ++i)
                s += TestNum.ToString();
            return s;
        }
        
        public static Student[] FillStudentsArray(int n)
        {
            Student[] students = new Student[n];
            for (int i = 0; i < n; ++i)
                students[i] = new Student(rnd.Next(1, 1000 + 1), rnd.Next(1, 9 + 1));
            return students;
        }

        public override string ToString()
        {
            return $"ID: {Id} TestNum: {TestNum} mark: {Mark}";
        }
    }
}
