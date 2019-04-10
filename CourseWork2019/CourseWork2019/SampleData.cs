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
                        CorrectAnswer = "2"
                    },
                    new Question
                    {
                        Name = "СИ",
                        QuestionContent = "Сколько байтов в килобайте?",
                  /*      AnswersList = new List<string>()
                        {
                            "1000", "1024", "1048", "8192", "986"
                        },*/
                        CorrectAnswer = "2"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Tests.Any())
            {
                context.Tests.Add(new Test() { Name = "Первый тест" });
            }

            if (!context.TestQuestions.Any())
            {
                context.TestQuestions.AddRange(
                    new TestQuestion() { TestId = 1, QuestionId = 1 }, 
                    new TestQuestion() { TestId = 1, QuestionId = 2 });
            }

            context.Questions.Add(new Question { Name = "<h1> Имя </h1>" });
        }
    }
}
