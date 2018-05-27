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
    public class OOADClanoviTimasController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADClanoviTimas
        public ActionResult Index()
        {
            var oOADClanoviTimas = db.OOADClanoviTimas.Include(o => o.OOADKorisnici).Include(o => o.OOADTimovi);
            return View(oOADClanoviTimas.ToList());
        }

        // GET: OOADClanoviTimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            if (oOADClanoviTima == null)
            {
                return HttpNotFound();
            }
            return View(oOADClanoviTima);
        }

        // GET: OOADClanoviTimas/Create
        public ActionResult Create()
        {
            ViewBag.Tim = new SelectList(db.OOADKorisnicis, "ID", "Username");
            ViewBag.Tim = new SelectList(db.OOADTimovis, "ID", "Ime");
            return View();
        }

        // POST: OOADClanoviTimas/Create
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Korisnik,Tim")] OOADClanoviTima oOADClanoviTima)
        {
            if (ModelState.IsValid)
            {
                db.OOADClanoviTimas.Add(oOADClanoviTima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tim = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADClanoviTima.Tim);
            ViewBag.Tim = new SelectList(db.OOADTimovis, "ID", "Ime", oOADClanoviTima.Tim);
            return View(oOADClanoviTima);
        }

        // GET: OOADClanoviTimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            if (oOADClanoviTima == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tim = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADClanoviTima.Tim);
            ViewBag.Tim = new SelectList(db.OOADTimovis, "ID", "Ime", oOADClanoviTima.Tim);
            return View(oOADClanoviTima);
        }

        // POST: OOADClanoviTimas/Edit/5
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Korisnik,Tim")] OOADClanoviTima oOADClanoviTima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADClanoviTima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tim = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADClanoviTima.Tim);
            ViewBag.Tim = new SelectList(db.OOADTimovis, "ID", "Ime", oOADClanoviTima.Tim);
            return View(oOADClanoviTima);
        }

        // GET: OOADClanoviTimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            if (oOADClanoviTima == null)
            {
                return HttpNotFound();
            }
            return View(oOADClanoviTima);
        }

        // POST: OOADClanoviTimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            db.OOADClanoviTimas.Remove(oOADClanoviTima);
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
