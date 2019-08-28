using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pollinator.Models;
using System;

namespace Pollinator.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private readonly PollinatorContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ResponsesController(UserManager<ApplicationUser> userManager, PollinatorContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var currentUser = await GetApplicationUser();
            return View (_db.Quizzes.Where(x => x.User.Id == currentUser.Id).ToList());
        }

        // public  ActionResult Create()
        // {
        //     return View();
        // }

        [HttpPost]
        public async Task<ActionResult> Create(Response response)
        {
            var currentUser = await GetApplicationUser();
            response.User = currentUser;
            Console.WriteLine($"response.QuizId = {response.QuizId}");
            _db.Responses.Add(response);
            _db.SaveChanges();
            return RedirectToAction("Index", "Quizzes");
        }

        // public ActionResult Details(int id)
        // {
        //     var thisQuiz = _db.Quizzes
        //         .Include(quiz => quiz.QuestionText)
        //         .ThenInclude(quiz =>)
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
            var userId = this.User.FindFirst (ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return currentUser;
        }
    }
}