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
    public class AnswersController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        // GET: Answers
        [NoDirectAccess]
        public ActionResult Index()
        {
            int aqid = int.Parse(HttpContext.Session["qId"].ToString());
            var answers = db.Answers.Include(a => a.Questions).Where(x => x.QId == aqid);
            return View(answers.ToList());
        }

        // GET: Answers/Details/5
        [NoDirectAccess]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            return View(answers);
        }

        // GET: Answers/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AId,QId,Answer")] Answers answers)
        {
            if (ModelState.IsValid)
            {
                answers.QId = int.Parse(HttpContext.Session["qId"].ToString());
                db.Answers.Add(answers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", answers.QId);
            return View(answers);
        }

        // GET: Answers/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", answers.QId);
            return View(answers);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [NoDirectAccess]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AId,QId,Answer")] Answers answers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", answers.QId);
            return View(answers);
        }

        // GET: Answers/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return HttpNotFound();
            }
            return View(answers);
        }

        // POST: Answers/Delete/5
        [NoDirectAccess]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QAnswers[] qAnswers = db.QAnswers.Where(x => x.AId == id).ToArray();
            foreach(QAnswers qA in qAnswers)
            {
                db.QAnswers.Remove(qA);
                db.SaveChanges();
            }
            Answers answers = db.Answers.Find(id);
            db.Answers.Remove(answers);
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
