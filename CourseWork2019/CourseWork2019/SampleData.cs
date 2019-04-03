using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWork2019.Models;

namespace CourseWork2019
{
    public static class SampleData
    {
        public static void Initialize(QuizContext context)
        {
            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Question
                    {
                        Name = "А вот и первый вопросик",
                        QuestionContent = "Сколько месяцев в году?",
                 /*       AnswersList = new List<string>()
                        {
                            "8", "10", "12", "14", "16"
                        },*/
                        CorrectAnswer = 2
                    },
                    new Question
                    {
                        Name = "СИ",
                        QuestionContent = "Сколько байтов в килобайте?",
                  /*      AnswersList = new List<string>()
                        {
                            "1000", "1024", "1048", "8192", "986"
                        },*/
                        CorrectAnswer = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
