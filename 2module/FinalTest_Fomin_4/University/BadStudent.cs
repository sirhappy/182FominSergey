/**
 * Программирование
 * Фомин Сергей
 * Вариант 4
**/

using System;

namespace University
{
    public class BadStudent : Student
    {
        /// <summary>
        ///     Конструктор плохого студента
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="course">Курс</param>
        /// <param name="marks">Массив оценок</param>
        /// <param name="hairStyle">Тип причёски</param>
        public BadStudent(string name, string surname, int course, int[] marks, string hairStyle)
            : base(name, surname, course, marks)
        {
            HairStyle = hairStyle;
            if (Mean > 4) throw new ArgumentException("Средний балл плохого студента не может быть больше 4!");
        }

        /// <summary>
        ///     Тип причёски
        /// </summary>
        public static string[] hairStyles = { "Undercut", "Bald", "Chubby" };
        private string _hairStyle;
        public string HairStyle
        {
            get => _hairStyle;
            protected set
            {
                _hairStyle = "";
                foreach (var i in hairStyles)
                    if (i == value) _hairStyle = i;
                if (_hairStyle == "") throw new ArgumentException("Неверный тип причёски!");
            }
        }

        /// <summary>
        ///     Рейтинг
        /// </summary>
        public override double Rating
        {
            get
            {
                if (HairStyle == hairStyles[2])
                    return Math.Truncate((Mean + Course) / (Mean * Course));
                else return Math.Truncate((Mean + Course) / (0.5 * Mean * Course)) % 12;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} Стиль причёски: {HairStyle}";
        }

    }
}
