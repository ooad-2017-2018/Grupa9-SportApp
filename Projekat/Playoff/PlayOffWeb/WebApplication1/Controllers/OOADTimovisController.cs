﻿using System;
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
    public class OOADTimovisController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADTimovis
        public ActionResult Index()
        {
            return View(db.OOADTimovis.ToList());
        }

        // GET: OOADTimovis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            if (oOADTimovi == null)
            {
                return HttpNotFound();
            }
            return View(oOADTimovi);
        }

        // GET: OOADTimovis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADTimovis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,KorisnikID,SportID,MMR")] OOADTimovi oOADTimovi)
        {
            if (ModelState.IsValid)
            {
                db.OOADTimovis.Add(oOADTimovi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADTimovi);
        }

        // GET: OOADTimovis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            if (oOADTimovi == null)
            {
                return HttpNotFound();
            }
            return View(oOADTimovi);
        }

        // POST: OOADTimovis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,KorisnikID,SportID,MMR")] OOADTimovi oOADTimovi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADTimovi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADTimovi);
        }

        // GET: OOADTimovis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            if (oOADTimovi == null)
            {
                return HttpNotFound();
            }
            return View(oOADTimovi);
        }

        // POST: OOADTimovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            db.OOADTimovis.Remove(oOADTimovi);
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
