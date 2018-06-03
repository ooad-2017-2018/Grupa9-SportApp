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
    public class OOADNaziviPozicijasController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADNaziviPozicijas
        public ActionResult Index()
        {
            return View(db.OOADNaziviPozicijas.ToList());
        }

        // GET: OOADNaziviPozicijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            if (oOADNaziviPozicija == null)
            {
                return HttpNotFound();
            }
            return View(oOADNaziviPozicija);
        }

        // GET: OOADNaziviPozicijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADNaziviPozicijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv")] OOADNaziviPozicija oOADNaziviPozicija)
        {
            if (ModelState.IsValid)
            {
                db.OOADNaziviPozicijas.Add(oOADNaziviPozicija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADNaziviPozicija);
        }

        // GET: OOADNaziviPozicijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            if (oOADNaziviPozicija == null)
            {
                return HttpNotFound();
            }
            return View(oOADNaziviPozicija);
        }

        // POST: OOADNaziviPozicijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv")] OOADNaziviPozicija oOADNaziviPozicija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADNaziviPozicija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADNaziviPozicija);
        }

        // GET: OOADNaziviPozicijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            if (oOADNaziviPozicija == null)
            {
                return HttpNotFound();
            }
            return View(oOADNaziviPozicija);
        }

        // POST: OOADNaziviPozicijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            db.OOADNaziviPozicijas.Remove(oOADNaziviPozicija);
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
