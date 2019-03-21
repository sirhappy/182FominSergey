/*
 * Фомин Сергей, кр за 3 модуль
 * Вариант 2
 * 
 * */

using System.Collections.Generic;

namespace Fomin_Control3module
{
    class Quiz<U, T> where U: class 
                     where T: struct
    {
        public List<U> QuizQuestions { get; set; } = new List<U>();

        public List<T> QuizAnswers { get; set; } = new List<T>();
    }
}
