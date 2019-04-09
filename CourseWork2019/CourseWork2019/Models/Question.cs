using System;

namespace CourseWork2019.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionContent { get; set; }
        public bool IsVariants { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }

        public enum QuestionTypes { Variants, Field }

        public QuestionTypes QuestionType { get; set; }

    }
}
