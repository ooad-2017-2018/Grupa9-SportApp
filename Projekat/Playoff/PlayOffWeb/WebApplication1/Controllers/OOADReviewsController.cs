using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OOADReviewsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADReviews
        public ActionResult Index()
        {
            return View(db.OOADReviews.ToList());
        }

        // GET: OOADReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADReview oOADReview = db.OOADReviews.Find(id);
            if (oOADReview == null)
            {
                return HttpNotFound();
            }
            return View(oOADReview);
        }

        // GET: OOADReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,komentar,ocjena,TIM")] OOADReview oOADReview)
        {
            if (ModelState.IsValid)
            {
                db.OOADReviews.Add(oOADReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADReview);
        }

        // GET: OOADReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADReview oOADReview = db.OOADReviews.Find(id);
            if (oOADReview == null)
            {
                return HttpNotFound();
            }
            return View(oOADReview);
        }

        // POST: OOADReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,komentar,ocjena,TIM")] OOADReview oOADReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADReview);
        }

        // GET: OOADReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADReview oOADReview = db.OOADReviews.Find(id);
            if (oOADReview == null)
            {
                return HttpNotFound();
            }
            return View(oOADReview);
        }

        // POST: OOADReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADReview oOADReview = db.OOADReviews.Find(id);
            db.OOADReviews.Remove(oOADReview);
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
