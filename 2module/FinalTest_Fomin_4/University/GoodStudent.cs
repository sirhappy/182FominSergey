/**
 * Программирование
 * Фомин Сергей
 * Вариант 4
**/

using System;

namespace University
{
    public class GoodStudent : Student
    {
        /// <summary>
        ///     Конструктор хорошего студента
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="course">Курс</param>
        /// <param name="marks">Оценки</param>
        /// <param name="glasses">Тип очков</param>
        public GoodStudent(string name, string surname, int course, int[] marks, string glasses)
            : base(name, surname, course, marks)
        {
            Glasses = glasses;
            if (Mean < 4) throw new ArgumentException("Средний балл хорошего студента не может быть ниже 4!");
        }

        /// <summary>
        ///     Тип очков
        /// </summary>
        public static string[] glassesStyles = { "None", "Round", "Square" }; 
        private string _glasses;
        public string Glasses
        {
            get => _glasses;
            protected set
            {
                _glasses = "";
                foreach (var i in glassesStyles)
                    if (i == value) _glasses = i;
                if (_glasses == "") throw new ArgumentException("Неверный тип очков!");
            }
        }

        /// <summary>
        ///     Рейтинг
        /// </summary>
        public override double Rating
        {
            get
            {
                if (Glasses == glassesStyles[0]) return Math.Truncate(Mean + 10);
                else return Math.Max(Mean, Course);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} Тип очков: {Glasses}";
        }
    }
}
