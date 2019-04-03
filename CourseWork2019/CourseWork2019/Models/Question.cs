using System;

namespace CourseWork2019.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionContent { get; set; }
        public int CorrectAnswer { get; set; }
    }
}