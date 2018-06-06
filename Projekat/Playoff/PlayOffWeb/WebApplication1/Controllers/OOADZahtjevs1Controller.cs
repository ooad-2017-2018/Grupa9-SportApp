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
    public class OOADZahtjevs1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADZahtjevs1
        public IQueryable<OOADZahtjev> GetOOADZahtjevs()
        {
            return db.OOADZahtjevs;
        }

        // GET: api/OOADZahtjevs1/5
        [ResponseType(typeof(OOADZahtjev))]
        public IHttpActionResult GetOOADZahtjev(int id)
        {
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            if (oOADZahtjev == null)
            {
                return NotFound();
            }

            return Ok(oOADZahtjev);
        }

        // PUT: api/OOADZahtjevs1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADZahtjev(int id, OOADZahtjev oOADZahtjev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADZahtjev.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADZahtjev).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADZahtjevExists(id))
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

        // POST: api/OOADZahtjevs1
        [ResponseType(typeof(OOADZahtjev))]
        public IHttpActionResult PostOOADZahtjev(OOADZahtjev oOADZahtjev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADZahtjevs.Add(oOADZahtjev);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADZahtjevExists(oOADZahtjev.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADZahtjev.ID }, oOADZahtjev);
        }

        // DELETE: api/OOADZahtjevs1/5
        [ResponseType(typeof(OOADZahtjev))]
        public IHttpActionResult DeleteOOADZahtjev(int id)
        {
            OOADZahtjev oOADZahtjev = db.OOADZahtjevs.Find(id);
            if (oOADZahtjev == null)
            {
                return NotFound();
            }

            db.OOADZahtjevs.Remove(oOADZahtjev);
            db.SaveChanges();

            return Ok(oOADZahtjev);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADZahtjevExists(int id)
        {
            return db.OOADZahtjevs.Count(e => e.ID == id) > 0;
        }
    }
}