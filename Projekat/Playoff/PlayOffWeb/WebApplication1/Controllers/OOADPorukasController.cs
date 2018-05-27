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
    public class OOADPorukasController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADPorukas
        public ActionResult Index()
        {
            var oOADPorukas = db.OOADPorukas.Include(o => o.OOADKorisnici).Include(o => o.OOADKorisnici1);
            return View(oOADPorukas.ToList());
        }

        // GET: OOADPorukas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            if (oOADPoruka == null)
            {
                return HttpNotFound();
            }
            return View(oOADPoruka);
        }

        // GET: OOADPorukas/Create
        public ActionResult Create()
        {
            ViewBag.Posiljaoc = new SelectList(db.OOADKorisnicis, "ID", "Username");
            ViewBag.Primaoc = new SelectList(db.OOADKorisnicis, "ID", "Username");
            return View();
        }

        // POST: OOADPorukas/Create
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sadrzaj,Posiljaoc,Primaoc,Vidjenost")] OOADPoruka oOADPoruka)
        {
            if (ModelState.IsValid)
            {
                db.OOADPorukas.Add(oOADPoruka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Posiljaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Posiljaoc);
            ViewBag.Primaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Primaoc);
            return View(oOADPoruka);
        }

        // GET: OOADPorukas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            if (oOADPoruka == null)
            {
                return HttpNotFound();
            }
            ViewBag.Posiljaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Posiljaoc);
            ViewBag.Primaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Primaoc);
            return View(oOADPoruka);
        }

        // POST: OOADPorukas/Edit/5
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sadrzaj,Posiljaoc,Primaoc,Vidjenost")] OOADPoruka oOADPoruka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADPoruka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Posiljaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Posiljaoc);
            ViewBag.Primaoc = new SelectList(db.OOADKorisnicis, "ID", "Username", oOADPoruka.Primaoc);
            return View(oOADPoruka);
        }

        // GET: OOADPorukas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            if (oOADPoruka == null)
            {
                return HttpNotFound();
            }
            return View(oOADPoruka);
        }

        // POST: OOADPorukas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            db.OOADPorukas.Remove(oOADPoruka);
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
