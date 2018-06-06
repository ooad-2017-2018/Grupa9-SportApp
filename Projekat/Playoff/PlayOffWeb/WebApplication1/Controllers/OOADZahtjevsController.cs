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
    public class OOADZahtjevsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADZahtjevs
        public ActionResult Index()
        {
            return View(db.OOADZahtjevs.ToList());
        }

        // GET: OOADZahtjevs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            if (oOADZahtjev == null)
            {
                return HttpNotFound();
            }
            return View(oOADZahtjev);
        }

        // GET: OOADZahtjevs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADZahtjevs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sadrzaj,Vidjenost,Primaoc,Posiljaoc")] OOADZahtjev oOADZahtjev)
        {
            if (ModelState.IsValid)
            {
                db.OOADZahtjevs.Add(oOADZahtjev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADZahtjev);
        }

        // GET: OOADZahtjevs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            if (oOADZahtjev == null)
            {
                return HttpNotFound();
            }
            return View(oOADZahtjev);
        }

        // POST: OOADZahtjevs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sadrzaj,Vidjenost,Primaoc,Posiljaoc")] OOADZahtjev oOADZahtjev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADZahtjev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADZahtjev);
        }

        // GET: OOADZahtjevs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            if (oOADZahtjev == null)
            {
                return HttpNotFound();
            }
            return View(oOADZahtjev);
        }

        // POST: OOADZahtjevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            db.OOADZahtjevs.Remove(oOADZahtjev);
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
