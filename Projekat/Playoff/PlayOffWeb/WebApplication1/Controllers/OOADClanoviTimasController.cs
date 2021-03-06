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
    public class OOADClanoviTimasController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADClanoviTimas
        public ActionResult Index()
        {
            return View(db.OOADClanoviTimas.ToList());
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
            return View();
        }

        // POST: OOADClanoviTimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View(oOADClanoviTima);
        }

        // POST: OOADClanoviTimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
