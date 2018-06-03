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
    public class OOADProsliTimovis1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADProsliTimovis1
        public IQueryable<OOADProsliTimovi> GetOOADProsliTimovis()
        {
            return db.OOADProsliTimovis;
        }

        // GET: api/OOADProsliTimovis1/5
        [ResponseType(typeof(OOADProsliTimovi))]
        public IHttpActionResult GetOOADProsliTimovi(int id)
        {
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            if (oOADProsliTimovi == null)
            {
                return NotFound();
            }

            return Ok(oOADProsliTimovi);
        }

        // PUT: api/OOADProsliTimovis1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADProsliTimovi(int id, OOADProsliTimovi oOADProsliTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADProsliTimovi.Korisnik)
            {
                return BadRequest();
            }

            db.Entry(oOADProsliTimovi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADProsliTimoviExists(id))
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

        // POST: api/OOADProsliTimovis1
        [ResponseType(typeof(OOADProsliTimovi))]
        public IHttpActionResult PostOOADProsliTimovi(OOADProsliTimovi oOADProsliTimovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADProsliTimovis.Add(oOADProsliTimovi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADProsliTimoviExists(oOADProsliTimovi.Korisnik))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADProsliTimovi.Korisnik }, oOADProsliTimovi);
        }

        // DELETE: api/OOADProsliTimovis1/5
        [ResponseType(typeof(OOADProsliTimovi))]
        public IHttpActionResult DeleteOOADProsliTimovi(int id)
        {
            OOADProsliTimovi oOADProsliTimovi = db.OOADProsliTimovis.Find(id);
            if (oOADProsliTimovi == null)
            {
                return NotFound();
            }

            db.OOADProsliTimovis.Remove(oOADProsliTimovi);
            db.SaveChanges();

            return Ok(oOADProsliTimovi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADProsliTimoviExists(int id)
        {
            return db.OOADProsliTimovis.Count(e => e.Korisnik == id) > 0;
        }
    }
}