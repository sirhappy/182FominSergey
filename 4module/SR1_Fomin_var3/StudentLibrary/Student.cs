/*
 * Студент: Фомин Сергей
 * Группа: БПИ182-2
 * Вариант 3
 * 12.04.2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{

    [Serializable]
    public class Student
    {
        /// <summary>
        ///     Конструктор по умолчанию
        /// </summary>
        public Student()
        {
            Height = 175;
            AverageMark = 2;
        }

        /// <summary>
        ///     Конструктор с параметрами
        /// </summary>
        /// <param name="height"></param>
        /// <param name="averageMark"></param>
        public Student(int height, double averageMark)
        {
            Height = height;
            AverageMark = averageMark;
        }
        public double AverageMark { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"Рост: {Height} см;  Средняя оценка: {AverageMark:F3}";
        }
    }
}
