using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using static Website.Global;

namespace Website.Controllers
{
    public class QuestionsController : Controller
    {

        private WebsiteContext db = new WebsiteContext();

        // GET: Questions
        public ActionResult Index()
        {

            return View(db.Questions.ToList());
        }

        // GET: Questions/Details/5
        [NoDirectAccess]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // GET: Questions/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [NoDirectAccess]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QId,Question,Method,Teacher")] Questions questions, [Bind(Include = "AId,QId,Answer")] Answers answers)
        {
            if (ModelState.IsValid)
            {
                //questions.Teacher = HttpContext.Session["uid"].ToString();
                questions.Teacher = User.Identity.Name;
                db.Questions.Add(questions);
                db.SaveChanges();
                var QIda = db.Questions.OrderByDescending(x => x.QId).FirstOrDefault(q => q.Teacher == questions.Teacher).QId;
                var answerarr = answers.Answer.Split(';');
                foreach (String a in answerarr)
                {
                    answers.QId = QIda;
                    answers.Answer = a;
                    db.Answers.Add(answers);
                    db.SaveChanges();
                }
                return RedirectToAction("Index","Questions");
            }

            return View(questions);
        }

        // GET: Questions/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
           /* Answers[] strarr = db.Answers.Where(x => x.QId == questions.QId).ToArray();
            Answers data = strarr[0];

            for(int i = 1; i < strarr.Count();i++)
            {
                data.Answer += ";" + strarr.ElementAt(i).Answer ;
            }*/
            BigView b = new BigView();
            b.Questions = questions;
            return View(b);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [NoDirectAccess]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QId,Question,Method,Teacher")] Questions questions)
        {
            if (ModelState.IsValid)
            {
                questions.Teacher = User.Identity.Name;
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                HttpContext.Session.Add("qId",questions.QId);
                return RedirectToAction("Index","Answers");
            }
            return View(questions);
        }

        // GET: Questions/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        // POST: Questions/Delete/5
        [NoDirectAccess]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QAnswers[] qAnswers = db.QAnswers.Where(x => x.QId == id).ToArray();
            foreach (QAnswers qA in qAnswers)
            {
                db.QAnswers.Remove(qA);
                db.SaveChanges();
            }
            Answers[] answers = db.Answers.Where(x => x.QId == id).ToArray();
            foreach (Answers a in answers)
            {
                db.Answers.Remove(a);
                db.SaveChanges();
            }
            Questions questions = db.Questions.Find(id);
            db.Questions.Remove(questions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
