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
            return View(db.OOADPorukas.ToList());
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
            return View();
        }

        // POST: OOADPorukas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View(oOADPoruka);
        }

        // POST: OOADPorukas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
