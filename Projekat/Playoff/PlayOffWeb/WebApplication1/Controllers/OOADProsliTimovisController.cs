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
    public class OOADProsliTimovisController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADProsliTimovis
        public ActionResult Index()
        {
            var oOADProsliTimovis = db.OOADProsliTimovis.Include(o => o.OOADKorisnici);
            return View(oOADProsliTimovis.ToList());
        }

        // GET: OOADProsliTimovis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            if (oOADProsliTimovi == null)
            {
                return HttpNotFound();
            }
            return View(oOADProsliTimovi);
        }

        // GET: OOADProsliTimovis/Create
        public ActionResult Create()
        {
            ViewBag.Korisnik = new SelectList(db.OOADKorisnicis, "ID", "Username");
            return View();
        }

        // POST: OOADProsliTimovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Korisnik,Naziv,datumprestanka")] OOADProsliTimovi oOADProsliTimovi)
        {
            if (ModelState.IsValid)
            {
                db.OOADProsliTimovis.Add(oOADProsliTimovi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Korisnik = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADProsliTimovi.Korisnik);
            return View(oOADProsliTimovi);
        }

        // GET: OOADProsliTimovis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            if (oOADProsliTimovi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Korisnik = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADProsliTimovi.Korisnik);
            return View(oOADProsliTimovi);
        }

        // POST: OOADProsliTimovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Korisnik,Naziv,datumprestanka")] OOADProsliTimovi oOADProsliTimovi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADProsliTimovi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Korisnik = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADProsliTimovi.Korisnik);
            return View(oOADProsliTimovi);
        }

        // GET: OOADProsliTimovis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            if (oOADProsliTimovi == null)
            {
                return HttpNotFound();
            }
            return View(oOADProsliTimovi);
        }

        // POST: OOADProsliTimovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            db.OOADProsliTimovis.Remove(oOADProsliTimovi);
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
