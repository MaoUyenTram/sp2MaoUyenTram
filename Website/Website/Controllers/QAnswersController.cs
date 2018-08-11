using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class QAnswersController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        // GET: QAnswers
        public ActionResult Index()
        {
            var qAnswers = db.QAnswers.Include(q => q.Answers).Include(q => q.Questions).Include(q => q.Users);
            return View(qAnswers.ToList());
        }

        // GET: QAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAnswers qAnswers = db.QAnswers.Find(id);
            if (qAnswers == null)
            {
                return HttpNotFound();
            }
            return View(qAnswers);
        }

        // GET: QAnswers/Create
        public ActionResult Create()
        {
            ViewBag.AId = new SelectList(db.Answers, "AId", "Answer");
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question");
            ViewBag.UId = new SelectList(db.Users, "UId", "User");
            return View();
        }

        // POST: QAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QId,AId,UId")] QAnswers qAnswers)
        {
            if (ModelState.IsValid)
            {
                db.QAnswers.Add(qAnswers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AId = new SelectList(db.Answers, "AId", "Answer", qAnswers.AId);
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", qAnswers.QId);
            ViewBag.UId = new SelectList(db.Users, "UId", "User", qAnswers.UId);
            return View(qAnswers);
        }

        // GET: QAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAnswers qAnswers = db.QAnswers.Find(id);
            if (qAnswers == null)
            {
                return HttpNotFound();
            }
            ViewBag.AId = new SelectList(db.Answers, "AId", "Answer", qAnswers.AId);
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", qAnswers.QId);
            ViewBag.UId = new SelectList(db.Users, "UId", "User", qAnswers.UId);
            return View(qAnswers);
        }

        // POST: QAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QId,AId,UId")] QAnswers qAnswers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qAnswers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AId = new SelectList(db.Answers, "AId", "Answer", qAnswers.AId);
            ViewBag.QId = new SelectList(db.Questions, "QId", "Question", qAnswers.QId);
            ViewBag.UId = new SelectList(db.Users, "UId", "User", qAnswers.UId);
            return View(qAnswers);
        }

        // GET: QAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAnswers qAnswers = db.QAnswers.Find(id);
            if (qAnswers == null)
            {
                return HttpNotFound();
            }
            return View(qAnswers);
        }

        // POST: QAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QAnswers qAnswers = db.QAnswers.Find(id);
            db.QAnswers.Remove(qAnswers);
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
