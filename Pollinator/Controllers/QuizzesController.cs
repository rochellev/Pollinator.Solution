using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Newtonsoft.Json;
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
            var currentUser = await GetApplicationUser();
            dynamic myModel = new ExpandoObject();
            myModel.Quizzes = _db.Quizzes;
            myModel.Responses = _db.Responses.ToList();

            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, 25),
                new DataPoint(20, 75),
                // new DataPoint(30, 10),    ----3rd data point

            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(myModel);
        }

        public ActionResult Create()
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

        // public ActionResult Details(int id)
        // {
        //     var thisQuiz = _db.Quizzes
        //         .Include(quiz => quiz.Responses)
        //         .ThenInclude(join => join.Response)
        //         .FirstOrDefault(quiz => quiz.QuizId == id);
        //     return View(thisQuiz);
        // }
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
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return currentUser;
        }

    }
}