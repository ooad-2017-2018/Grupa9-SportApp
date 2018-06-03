using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OOADTimovis1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADTimovis1
        public IQueryable<OOADTimovi> GetOOADTimovis()
        {
            return db.OOADTimovis;
        }

        // GET: api/OOADTimovis1/5
        [ResponseType(typeof(OOADTimovi))]
        public IHttpActionResult GetOOADTimovi(int id)
        {
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            if (oOADTimovi == null)
            {
                return NotFound();
            }

            return Ok(oOADTimovi);
        }

        // PUT: api/OOADTimovis1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADTimovi(int id, OOADTimovi oOADTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADTimovi.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADTimovi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADTimoviExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OOADTimovis1
        [ResponseType(typeof(OOADTimovi))]
        public IHttpActionResult PostOOADTimovi(OOADTimovi oOADTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADTimovis.Add(oOADTimovi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADTimoviExists(oOADTimovi.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADTimovi.ID }, oOADTimovi);
        }

        // DELETE: api/OOADTimovis1/5
        [ResponseType(typeof(OOADTimovi))]
        public IHttpActionResult DeleteOOADTimovi(int id)
        {
            OOADTimovi oOADTimovi = db.OOADTimovis.Find(id);
            if (oOADTimovi == null)
            {
                return NotFound();
            }

            db.OOADTimovis.Remove(oOADTimovi);
            db.SaveChanges();

            return Ok(oOADTimovi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADTimoviExists(int id)
        {
            return db.OOADTimovis.Count(e => e.ID == id) > 0;
        }
    }
}