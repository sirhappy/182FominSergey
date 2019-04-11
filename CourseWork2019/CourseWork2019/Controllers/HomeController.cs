using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork2019.Models;
using System.Web;
using CourseWork2019.Utilities;

namespace CourseWork2019.Controllers
{
    public class HomeController : Controller
    {
        QuizContext db;

        public HomeController(QuizContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        [HttpGet]
        public IActionResult Test(int id)
        {
            ViewBag.TestId = id;
            
            List<TestQuestion> testQuestions = db.TestQuestions.Where(t => t.TestId == id).ToList();

            List<int> questionsId = testQuestions.Select(t => t.QuestionId).ToList();
  
            List<Question> questions = db.Questions.Where(t => questionsId.Contains(t.Id)).ToList();

            List<ViewQuestion> viewQuestions = new List<ViewQuestion>();
            foreach (var i in questions)
            {
                ViewQuestion viewQuestion = new ViewQuestion();
                viewQuestion.Id = i.Id;
                viewQuestion.Name = i.Name;
                viewQuestion.QuestionContent = i.QuestionContent;
                List<string> answers = new List<string>();
                answers.Add(i.CorrectAnswer);
                answers.Add(i.WrongAnswer1);
                answers.Add(i.WrongAnswer2);
                answers.Add(i.WrongAnswer3);
                viewQuestion.Answers.AddRange(answers.OrderBy(x => RandomClass.Rnd.Next()));
                viewQuestions.Add(viewQuestion);
            }
            
            return View(viewQuestions);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            question.QuestionContent = HttpUtility.HtmlDecode(question.QuestionContent);
            db.Questions.Add(question);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
