using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pollinator.Models;


namespace Pollinator.Controllers
{
    [Authorize]
    public class QuizzesController : Controller
    {
        private readonly PollinatorContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public QuizzesController(UserManager<ApplicationUser> userManager, PollinatorContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            // List<Quiz> model = _db.Quizzes.ToList();
            // return View();
            var currentUser = await GetApplicationUser();
            return View (_db.Quizzes.Where(x => x.User.Id == currentUser.Id).ToList());
        }

        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Quiz quiz)
        {
            var currentUser = await GetApplicationUser();
            quiz.User = currentUser;
            _db.Quizzes.Add(quiz);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        public ActionResult Details(int id)
        {
            //strict check
            var thisQuiz = _db.Quizzes
                .Include(quiz => quiz.Questions)
                .ThenInclude(join => join.Question)
                .FirstOrDefault(quiz => quiz.QuizId == id);
            return View(thisQuiz);
        }
=======
        // public ActionResult Details(int id)
        // {
        //     var thisQuiz = _db.Quizzes
        //         .Include(quiz => quiz.QuestionText)
        //         .ThenInclude(quiz =>)
        //         .FirstOrDefault(quiz => quiz.QuizId == id);
        //     return View(thisQuiz);
        // }
>>>>>>> eb2d6fa9c90b577951a3966370953e4ff3396b89
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
        private async Task<ApplicationUser> GetApplicationUser()
        {
            var userId = this.User.FindFirst (ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return currentUser;
        }
    }
}