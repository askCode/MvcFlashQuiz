
using FlashQuiz_2ndAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlashQuiz_2ndAttempt.Controllers
{
    public class HomeController : Controller
    {
        //Initialize a database
        FlashQuizDb2 _db = new FlashQuizDb2();

        public ActionResult Index(string searchTerm)
        {
            //var model = _db.Quizzes.ToList();

            //Comprehension query syntax
            //var model = from r in _db.Quizzes
            //            orderby r.QuizQuestions.Count() descending
            //            select new QuizListViewModel{
            //                Id = r.Id,
            //                QuizName = r.QuizName,
            //                QuizTopic = r.QuizTopic,
            //                CreatedBy = r.UserName,
            //                NumberOfQuestions = r.QuizQuestions.Count()
            //            };

            //Extension query syntax
            var model= _db.Quizzes
                       .Where(r => searchTerm == null || r.QuizTopic.StartsWith(searchTerm) || r.QuizTopic.Contains(searchTerm))
                       .OrderByDescending(r => r.QuizTopic)
                       .Select( r => new QuizListViewModel{
                            Id = r.Id,
                            QuizName = r.QuizName,
                            QuizTopic = r.QuizTopic,
                            CreatedBy = r.UserName,
                            NumberOfQuestions = r.QuizQuestions.Count()
                        });


            return View(model);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";
            //ViewBag.Location = "Maryland, USA";

            //Use the Models/AboutModel to pass info to the view
            var model = new AboutModel();
            model.Name = "Ajit";
            model.Location = "Hamilton, New Zealand";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
