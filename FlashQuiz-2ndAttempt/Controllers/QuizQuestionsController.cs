using FlashQuiz_2ndAttempt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Added the QuizQuestions controller using the MVC Empty Read/Write Actions scaffolding
namespace FlashQuiz_2ndAttempt.Controllers
{
    public class QuizQuestionsController : Controller
    {

        //Instantiate the database source
        FlashQuizDb2 _db = new FlashQuizDb2();


        //GET //QuizQuestions/TakeQuiz/5
        public ActionResult TakeQuiz([Bind(Prefix = "id")] int QuizId)
        {
            var quiz = _db.Quizzes.Find(QuizId)
                       .QuizQuestions
                       .Select(r => new TakeQuizModel
                       {
                           Question = r.Question,
                           Correct = r.Answer,
                           Wrong1 = r.WrongAnswer1,
                           Wrong2 = r.WrongAnswer2,
                           Wrong3 = r.WrongAnswer3
                       });

            return Json(quiz,JsonRequestBehavior.AllowGet);

        }

        //
        // GET: /QuizQuestions/Index/5

        public ActionResult Index([Bind(Prefix = "id")] int QuizId)
        {
            // The Bind attribute tells the controller to look for an QuizId which looks like id
            //The Bind attribute is a way of aliasing the search for the model

            //var model = from r in _quizQuestions
            //            orderby r.Answer
            //            select r;
                
            //return View(model);

            var quiz = _db.Quizzes.Find(QuizId);

            if (quiz != null)
            {
                return View(quiz);
            }

            return HttpNotFound();
        }


        // GET /Create?QuizId=5
        [HttpGet]
        public ActionResult Create(int QuizId) 
        {
            return View();
        }

        // POST /Create/
        [HttpPost]
        public ActionResult Create(QuizQuestion q)
        {
            if (ModelState.IsValid)
            {
                _db.QuizQuestions.Add(q);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = q.QuizId });
            }
            return View(q);
        }


        // GET //QuizQuestions/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.QuizQuestions.Find(id);
            return View(model);
        }

        //POST /QuizQuestion/Edit
        [HttpPost]
        public ActionResult Edit(QuizQuestion q)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(q).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = q.QuizId });
            }
            return View(q);
        }
        
        //GET /QuizQuestions/Delete

        //
        // GET: /QuizQuestions/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            QuizQuestion q = _db.QuizQuestions.Find(id);
            if (q == null)
            {
                return HttpNotFound();
            }
            return View(q);
        }

        //
        // POST: /QuizQuestions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizQuestion q = _db.QuizQuestions.Find(id);
            _db.QuizQuestions.Remove(q);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = q.QuizId });
        }

        //Dispose the db connection
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public IEnumerable<Quiz> QuizQuestions { get; set; }
    }
}
