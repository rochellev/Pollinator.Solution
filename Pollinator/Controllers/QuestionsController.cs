// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Pollinator.Models;
// using Microsoft.AspNetCore.Mvc.Rendering;

// namespace Pollinator.Controllers
// {
//     [Authorize]
//     public class QuestionsController : Controller
//     {
//         private readonly PollinatorContext _db;
//         private readonly UserManager<ApplicationUser> _userManager;

//         public QuestionsController(UserManager<ApplicationUser> userManager, PollinatorContext db)
//         {
//             _userManager = userManager;
//             _db = db;
//         }

//         public async Task<ActionResult> Index()
//         {
//             var currentUser = await GetApplicationUser();
//             return View(_db.Questions.Where(x => x.User.Id ==currentUser.Id).ToList())
//             // List<Question> model = _db.Questions.ToList();
//             // return View(model);
//         }

//         public ActionResult Create()
//         {
//             // ViewBag.QuizId = new SelectList(_db.Quizzes, "QuizId", "Name");
//             return View();
//         }

//         [HttpPost]
//         public async Task<ActionResult> Create(Question question)
//         {
//             _db.Questions.Add(question);
//             if(QuizId != 0)
//             {
//                 _db.QuizQuestion.Add(new QuizQuestion() {QuizId = QuizId, QuestionId = question.QuestionId});
//             }
//             _db.SaveChanges();
//             return RedirectToAction("Index");
//         }

//         public ActionResult Details(int id)
//         {
//             var thisQestion = _db.Questions
//                 .Include(question => question.Quizzes)
//                 .ThenInclude(join => join.Quiz)
//                 .FirstOrDefault(question => question.QuestionId == id);
//             return View(thisQestion);
//         }
//     }
// }