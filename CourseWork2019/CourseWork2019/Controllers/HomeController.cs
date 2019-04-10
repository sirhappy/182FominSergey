using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork2019.Models;
using System.Web;

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
            
            List<TestQuestion> TestQuestions = db.TestQuestions.Where(t => t.TestId == id).ToList();

            List<int> QuestionsId = TestQuestions.Select(t => t.QuestionId).ToList();
  
            List<Question> Questions = db.Questions.Where(t => QuestionsId.Contains(t.Id)).ToList();

            return View(Questions.ToList());
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
