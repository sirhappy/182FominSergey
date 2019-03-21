/*
 * Фомин Сергей, кр за 3 модуль
 * Вариант 2
 * 
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomin_Control3module
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Tester tester = new Tester() { Department = "Министерство магии, отдел тайн" };
                string path = "quiz.txt";
                tester.GenerateQuiz(path);

                Console.Write("Введите количество кандидатов: ");
                int N;
                while (!int.TryParse(Console.ReadLine(), out N) || N < 0 || N > 100000)
                    Console.WriteLine("N должно быть в диапазоне от 0 до 100000!");

                Candidate[] candidates = new Candidate[N];
                for (int i = 0; i < N; ++i)
                    candidates[i] = new Candidate(GetSurname(), tester);

                tester.StartTest();

                tester.GetCandidateAnswersAndFinishTest();

                path = "results.txt";
                tester.PrintExamResults(path);

                Console.WriteLine("Для выхода из программы нажмите ESC, иначе любую другую клавищу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        private static void Tester_OnStartTest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static Random rnd = new Random();
        private static string GetSurname()
        {
            string[] surnames = { "Иванов", "Петров", "Сидоров" };
            return surnames[rnd.Next(surnames.Length)];
        }
    }

    class Tester
    {
        public string Department { get; set; }

        Quiz<string, int> quiz = new Quiz<string, int>();

        public void GenerateQuiz(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        if (!s.Contains(";"))
                        {
                            Console.WriteLine("Какая-то строка не содержит ;");
                            continue;
                        }
                        string question = s.Substring(0, s.IndexOf(';') - 1);
                        int answer = -10;
                        int.TryParse(s.Substring(s.IndexOf(';') + 1).Trim(), out answer);
                        quiz.QuizAnswers.Add(answer);
                        quiz.QuizQuestions.Add(question);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Создайте файл вида \n Вопрос ; ответ \n quiz.txt в папке с исполняемым файлом");

            }
            catch (Exception ex)
            {
                Console.WriteLine("GenerateQuiz");
                Console.WriteLine(ex.Message);
            }
        }

        public event EventHandler<TestEventArgs> OnStartTest;
        public void StartTest()
        {
            Quiz<string, int> quizForCandidate = new Quiz<string, int>();
            quizForCandidate.QuizQuestions = quiz.QuizQuestions;
            OnStartTest?.Invoke(this, new TestEventArgs(quizForCandidate));
        }

        public event EventHandler OnGetCandidateAnswersAndFinishTest;
        public void GetCandidateAnswersAndFinishTest()
        {
            OnGetCandidateAnswersAndFinishTest?.Invoke(this, new EventArgs());
        }

        List<CandidateAnswers> candidateAnswers = new List<CandidateAnswers>();
        public void RegisterCandidateAnswers(Candidate candidate, CandidateAnswers answers)
        {
            candidateAnswers.Add(answers);
        }

        public void CheckCandidateAnswers()
        {
            for (int i = 0; i < candidateAnswers.Count; ++i)
            {
                int cnt = 0;
                for (int j = 0; j < candidateAnswers[i].Answers.Count; ++j)
                {
                    if (candidateAnswers[i].Answers[j] == quiz.QuizAnswers[i]) ++cnt;
                }
                candidateAnswers[i].Mark = 3; //(int)Math.Round((double)cnt / quiz.QuizAnswers.Count * 100);
            }
        }

        public void PrintExamResults(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach(var i in candidateAnswers)
                    {
                        sw.WriteLine($"{i.Surname}: {i.Mark}");
                    }
                }
            }
        }
    }

    class Candidate
    {

        public Candidate(string surname, Tester tester)
        {
            Surname = surname;
            this.tester = tester;
            // подписать на оба события
            tester.OnStartTest += (sender, e) => quiz = e.Quiz;
            CandidateAnswers candidateAnswers = new CandidateAnswers();
            tester.OnGetCandidateAnswersAndFinishTest += (sender, e) =>
            {
                for (int i = 0; i < quiz.QuizQuestions.Count; ++i)
                    candidateAnswers.Answers.Add(Program.rnd.Next(-5, 6));

                tester.RegisterCandidateAnswers(this, candidateAnswers);
            };
            
        }

        string Surname { get; set; }

        readonly Tester tester;

        Quiz<string, int> quiz;
    }

    class TestEventArgs : EventArgs
    {
        public Quiz<string, int> Quiz { get; }
        public TestEventArgs()
        {
            Quiz = new Quiz<string, int>();
        }
        public TestEventArgs(Quiz<string, int> quiz)
        {
            Quiz = quiz;
        }
    }
}
