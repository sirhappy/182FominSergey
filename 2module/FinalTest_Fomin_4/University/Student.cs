/**
 * Программирование
 * Фомин Сергей
 * Вариант 4
**/

using System;

namespace University
{
    /// <summary>
    ///     Exception для оценки вне диапазона [0; 10]
    /// </summary>
    public class NotAppropriateMarkException : Exception
    {
        public NotAppropriateMarkException()
        {
        }

        public NotAppropriateMarkException(string message) : base(message)
        {
            message += "Оценка не из диапазона [0; 10]";
        }
    }

    abstract public class Student
    {
        /// <summary>
        ///     Конструктор Student
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="course">Курс</param>
        /// <param name="marks">Массив оценок</param>
        public Student(string name, string surname, int course, int[] marks)
        {
            Name = name;
            Surname = surname;
            Course = course;
            this.marks = new int[marks.Length];
            for (int i = 0; i < marks.Length; ++i)
            {
                if (0 <= marks[i] && marks[i] <= 10) this.marks[i] = marks[i];
                else throw new NotAppropriateMarkException();
            }
        }

        /// <summary>
        ///     Имя
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string Surname { get; protected set; }

        /// <summary>
        ///     Курс
        /// </summary>
        private int _course;
        public int Course
        {
            get => _course;
            set
            {
                if (value >= 1 && value <= 4) _course = value;
                else throw new ArgumentException("Курс должен быть в диапазоне [1; 4]");
            }
        }

        /// <summary>
        ///     Массив оценок
        /// </summary>
        int[] marks;

        /// <summary>
        ///     Средняя оценка
        /// </summary>
        public double Mean
        {
            get
            {
                int res = 0;
                for (int i = 0; i < marks.Length; ++i)
                    res += marks[i];
                return (double)res / marks.Length;
            }
        }

        /// <summary>
        ///     Свойство для получения рейтинга
        /// </summary>
        abstract public double Rating { get; }
        
        public override string ToString()
        {
            return $"{Name} {Surname} Курс: {Course} Средний балл: {Mean:F3}";
        }

    }
}
