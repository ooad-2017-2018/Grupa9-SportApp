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
    public class OOADKorisnicisController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADKorisnicis
        public ActionResult Index()
        {
            return View(db.OOADKorisnicis.ToList());
        }

        // GET: OOADKorisnicis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            if (oOADKorisnici == null)
            {
                return HttpNotFound();
            }
            return View(oOADKorisnici);
        }

        // GET: OOADKorisnicis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADKorisnicis/Create
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Ime,Prezime,Rodjen,drzava,grad,dostupnost")] OOADKorisnici oOADKorisnici)
        {
            if (ModelState.IsValid)
            {
                db.OOADKorisnicis.Add(oOADKorisnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADKorisnici);
        }

        // GET: OOADKorisnicis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            if (oOADKorisnici == null)
            {
                return HttpNotFound();
            }
            return View(oOADKorisnici);
        }

        // POST: OOADKorisnicis/Edit/5
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Ime,Prezime,Rodjen,drzava,grad,dostupnost")] OOADKorisnici oOADKorisnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADKorisnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADKorisnici);
        }

        // GET: OOADKorisnicis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            if (oOADKorisnici == null)
            {
                return HttpNotFound();
            }
            return View(oOADKorisnici);
        }

        // POST: OOADKorisnicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            db.OOADKorisnicis.Remove(oOADKorisnici);
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
