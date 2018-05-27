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
    public class OOADSportsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADSports
        public ActionResult Index()
        {
            return View(db.OOADSports.ToList());
        }

        // GET: OOADSports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSport oOADSport = db.OOADSports.Find(id);
            if (oOADSport == null)
            {
                return HttpNotFound();
            }
            return View(oOADSport);
        }

        // GET: OOADSports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADSports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,MaxBrojIgraca,MinBrojIgraca")] OOADSport oOADSport)
        {
            if (ModelState.IsValid)
            {
                db.OOADSports.Add(oOADSport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADSport);
        }

        // GET: OOADSports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSport oOADSport = db.OOADSports.Find(id);
            if (oOADSport == null)
            {
                return HttpNotFound();
            }
            return View(oOADSport);
        }

        // POST: OOADSports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,MaxBrojIgraca,MinBrojIgraca")] OOADSport oOADSport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADSport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADSport);
        }

        // GET: OOADSports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSport oOADSport = db.OOADSports.Find(id);
            if (oOADSport == null)
            {
                return HttpNotFound();
            }
            return View(oOADSport);
        }

        // POST: OOADSports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADSport oOADSport = db.OOADSports.Find(id);
            db.OOADSports.Remove(oOADSport);
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
