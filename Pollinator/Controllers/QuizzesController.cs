using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pollinator.Models;

namespace Pollinator.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly PollinatorContext _db;
        public QuizzesController(PollinatorContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Quiz> model = _db.Quizzes.ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Quiz quiz)
        {
            _db.Quizzes.Add(quiz);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisQuiz = _db.Quizzes
                .Include(quiz => quiz.Questions)
                .ThenInclude(join => join.Question)
                .FirstOrDefault(quiz => quiz.QuizId == id);
            return View(thisQuiz);
        }
        public ActionResult Edit(int id)
        {
            var thisQuiz = _db.Quizzes.FirstOrDefault(quiz => quiz.QuizId == id);
            return View(thisQuiz);
        }
        [HttpPost]
        public ActionResult Edit(Quiz quiz)
        {
            _db.Entry(quiz).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisQuiz = _db.Quizzes.FirstOrDefault(quiz => quiz.QuizId == id);
            return View(thisQuiz);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisQuiz = _db.Quizzes.FirstOrDefault(quiz => quiz.QuizId == id);
            _db.Quizzes.Remove(thisQuiz);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}