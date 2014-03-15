using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlashQuiz_2ndAttempt.Models;

namespace FlashQuiz_2ndAttempt.Controllers
{
    public class TakeQuizController : Controller
    {
        private FlashQuizDb2 db = new FlashQuizDb2();

        //
        // GET: /TakeQuiz/

        public ActionResult Index()
        {
            var model = db.Quizzes
                       .OrderByDescending(r => r.QuizTopic)
                       .Select(r => new QuizListViewModel
                       {
                           Id = r.Id,
                           QuizName = r.QuizName,
                           QuizTopic = r.QuizTopic,
                           CreatedBy = r.UserName,
                           NumberOfQuestions = r.QuizQuestions.Count()
                       });


            return View(model);
        }

        //GET //QuizQuestions/TakeQuiz/5
        public ActionResult Quiz([Bind(Prefix = "id")] int QuizId)
        {
            var quiz = db.Quizzes.Find(QuizId)
                       .QuizQuestions
                       .Select(r => new TakeQuizModel
                       {
                           Question = r.Question,
                           Correct = r.Answer,
                           Wrong1 = r.WrongAnswer1,
                           Wrong2 = r.WrongAnswer2,
                           Wrong3 = r.WrongAnswer3
                       });

           // return Json(quiz, JsonRequestBehavior.AllowGet);
            return View(quiz);

        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}