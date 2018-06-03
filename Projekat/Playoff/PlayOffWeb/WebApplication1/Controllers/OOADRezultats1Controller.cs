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
    public class OOADRezultats1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADRezultats1
        public IQueryable<OOADRezultat> GetOOADRezultats()
        {
            return db.OOADRezultats;
        }

        // GET: api/OOADRezultats1/5
        [ResponseType(typeof(OOADRezultat))]
        public IHttpActionResult GetOOADRezultat(int id)
        {
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            if (oOADRezultat == null)
            {
                return NotFound();
            }

            return Ok(oOADRezultat);
        }

        // PUT: api/OOADRezultats1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADRezultat(int id, OOADRezultat oOADRezultat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADRezultat.MecID)
            {
                return BadRequest();
            }

            db.Entry(oOADRezultat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADRezultatExists(id))
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

        // POST: api/OOADRezultats1
        [ResponseType(typeof(OOADRezultat))]
        public IHttpActionResult PostOOADRezultat(OOADRezultat oOADRezultat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADRezultats.Add(oOADRezultat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADRezultatExists(oOADRezultat.MecID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADRezultat.MecID }, oOADRezultat);
        }

        // DELETE: api/OOADRezultats1/5
        [ResponseType(typeof(OOADRezultat))]
        public IHttpActionResult DeleteOOADRezultat(int id)
        {
            OOADRezultat oOADRezultat = db.OOADRezultats.Find(id);
            if (oOADRezultat == null)
            {
                return NotFound();
            }

            db.OOADRezultats.Remove(oOADRezultat);
            db.SaveChanges();

            return Ok(oOADRezultat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADRezultatExists(int id)
        {
            return db.OOADRezultats.Count(e => e.MecID == id) > 0;
        }
    }
}