/*
 * Фомин Сергей, кр за 3 модуль
 * Вариант 2
 * 
 * */

using System;
using System.Collections.Generic;

namespace Fomin_Control3module
{
    class CandidateAnswers
    {
        public int Surname { get; set; }

        public List<int> Answers { get; set; } = new List<int>();

        private int _mark;
        public int Mark {
            get
            {
                return _mark;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Оценка должна быть в пределах [0; 100]!");
                _mark = value;
            }
        }
    }
}
