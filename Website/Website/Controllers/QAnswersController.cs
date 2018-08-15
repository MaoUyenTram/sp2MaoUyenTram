using Newtonsoft.Json;
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
    public class QAnswersController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        [NoDirectAccess]
        public ActionResult XYChartView(int? id)
        {
            var chartData = (from aid in db.Answers
                             join qaid in db.QAnswers on aid.AId equals qaid.AId
                             where qaid.QId == id
                             group aid by aid.Answer into ai
                             select new Data { Name = ai.Key, Count = ai.Count() }).ToList();
            ViewBag.DataPoints = ToData.ToDataSet(chartData);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            var temp = questions.Method;
            questions.Method = temp.First().ToString().ToUpper() + temp.Substring(1, temp.Length-6);
            return View(questions);
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
