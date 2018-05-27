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
    public class OOADRezultatsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADRezultats
        public ActionResult Index()
        {
            var oOADRezultats = db.OOADRezultats.Include(o => o.OOADMec);
            return View(oOADRezultats.ToList());
        }

        // GET: OOADRezultats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            if (oOADRezultat == null)
            {
                return HttpNotFound();
            }
            return View(oOADRezultat);
        }

        // GET: OOADRezultats/Create
        public ActionResult Create()
        {
            ViewBag.MecID = new SelectList(db.OOADMecs, "ID", "MjestoOdrzavanja");
            return View();
        }

        // POST: OOADRezultats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MecID,TIM1rez,TIM2rez")] OOADRezultat oOADRezultat)
        {
            if (ModelState.IsValid)
            {
                db.OOADRezultats.Add(oOADRezultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MecID = new SelectList(db.OOADMecs, "ID", "MjestoOdrzavanja", oOADRezultat.MecID);
            return View(oOADRezultat);
        }

        // GET: OOADRezultats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            if (oOADRezultat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MecID = new SelectList(db.OOADMecs, "ID", "MjestoOdrzavanja", oOADRezultat.MecID);
            return View(oOADRezultat);
        }

        // POST: OOADRezultats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MecID,TIM1rez,TIM2rez")] OOADRezultat oOADRezultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADRezultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MecID = new SelectList(db.OOADMecs, "ID", "MjestoOdrzavanja", oOADRezultat.MecID);
            return View(oOADRezultat);
        }

        // GET: OOADRezultats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            if (oOADRezultat == null)
            {
                return HttpNotFound();
            }
            return View(oOADRezultat);
        }

        // POST: OOADRezultats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            db.OOADRezultats.Remove(oOADRezultat);
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
