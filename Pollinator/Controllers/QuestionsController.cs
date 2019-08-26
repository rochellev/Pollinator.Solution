using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pollinator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pollinator.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly PollinatorContext _db;
        public QuestionsController(PollinatorContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Question> model = _db.Questions.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(_db.Quizzes, "QuizId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question, int QuizId)
        {
            _db.Questions.Add(question);
            if(QuizId != 0)
            {
                _db.QuizQuestion.Add(new QuizQuestion() {QuizId = QuizId, QuestionId = question.QuestionId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisQestion = _db.Questions
                .Include(question => question.Quizzes)
                .ThenInclude(join => join.Quiz)
                .FirstOrDefault(question => question.QuestionId == id);
            return View(thisQestion);
        }
    }
}