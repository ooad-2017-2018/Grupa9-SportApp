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
    public class OOADSampionatsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADSampionats
        public ActionResult Index()
        {
            return View(db.OOADSampionats.ToList());
        }

        // GET: OOADSampionats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            if (oOADSampionat == null)
            {
                return HttpNotFound();
            }
            return View(oOADSampionat);
        }

        // GET: OOADSampionats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADSampionats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,TimoviID")] OOADSampionat oOADSampionat)
        {
            if (ModelState.IsValid)
            {
                db.OOADSampionats.Add(oOADSampionat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADSampionat);
        }

        // GET: OOADSampionats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            if (oOADSampionat == null)
            {
                return HttpNotFound();
            }
            return View(oOADSampionat);
        }

        // POST: OOADSampionats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,TimoviID")] OOADSampionat oOADSampionat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADSampionat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADSampionat);
        }

        // GET: OOADSampionats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            if (oOADSampionat == null)
            {
                return HttpNotFound();
            }
            return View(oOADSampionat);
        }

        // POST: OOADSampionats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            db.OOADSampionats.Remove(oOADSampionat);
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
