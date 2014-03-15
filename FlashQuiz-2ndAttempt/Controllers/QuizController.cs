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
    public class QuizController : Controller
    {
        private FlashQuizDb2 db = new FlashQuizDb2();

        //
        // GET: /Quiz/

        public ActionResult Index()
        {
            return View(db.Quizzes.ToList());
        }

        //
        // GET: /Quiz/Details/5

        public ActionResult Details(int id = 0)
        {
            Quiz quiz = db.Quizzes.Find(id);

            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        //
        // GET: /Quiz/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Quiz/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizzes.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        //
        // GET: /Quiz/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        //
        // POST: /Quiz/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        //
        // GET: /Quiz/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        //
        // POST: /Quiz/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz quiz = db.Quizzes.Find(id);
            db.Quizzes.Remove(quiz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}