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
    public class OOADMecsController : Controller
    {
        private PlayoffM db = new PlayoffM();

        // GET: OOADMecs
        public ActionResult Index()
        {
            return View(db.OOADMecs.ToList());
        }

        // GET: OOADMecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADMec oOADMec = db.OOADMecs.Find(id);
            if (oOADMec == null)
            {
                return HttpNotFound();
            }
            return View(oOADMec);
        }

        // GET: OOADMecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OOADMecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VrijemeOdrzavanja,MjestoOdrzavanja,TIM1,TIM2")] OOADMec oOADMec)
        {
            if (ModelState.IsValid)
            {
                db.OOADMecs.Add(oOADMec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oOADMec);
        }

        // GET: OOADMecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADMec oOADMec = db.OOADMecs.Find(id);
            if (oOADMec == null)
            {
                return HttpNotFound();
            }
            return View(oOADMec);
        }

        // POST: OOADMecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VrijemeOdrzavanja,MjestoOdrzavanja,TIM1,TIM2")] OOADMec oOADMec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oOADMec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oOADMec);
        }

        // GET: OOADMecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OOADMec oOADMec = db.OOADMecs.Find(id);
            if (oOADMec == null)
            {
                return HttpNotFound();
            }
            return View(oOADMec);
        }

        // POST: OOADMecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OOADMec oOADMec = db.OOADMecs.Find(id);
            db.OOADMecs.Remove(oOADMec);
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
