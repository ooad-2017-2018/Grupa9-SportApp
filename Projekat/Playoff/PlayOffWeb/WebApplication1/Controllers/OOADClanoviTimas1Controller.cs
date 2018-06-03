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
    public class OOADClanoviTimas1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADClanoviTimas1
        public IQueryable<OOADClanoviTima> GetOOADClanoviTimas()
        {
            return db.OOADClanoviTimas;
        }

        // GET: api/OOADClanoviTimas1/5
        [ResponseType(typeof(OOADClanoviTima))]
        public IHttpActionResult GetOOADClanoviTima(int id)
        {
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            if (oOADClanoviTima == null)
            {
                return NotFound();
            }

            return Ok(oOADClanoviTima);
        }

        // PUT: api/OOADClanoviTimas1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADClanoviTima(int id, OOADClanoviTima oOADClanoviTima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADClanoviTima.Korisnik)
            {
                return BadRequest();
            }

            db.Entry(oOADClanoviTima).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADClanoviTimaExists(id))
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

        // POST: api/OOADClanoviTimas1
        [ResponseType(typeof(OOADClanoviTima))]
        public IHttpActionResult PostOOADClanoviTima(OOADClanoviTima oOADClanoviTima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADClanoviTimas.Add(oOADClanoviTima);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADClanoviTimaExists(oOADClanoviTima.Korisnik))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADClanoviTima.Korisnik }, oOADClanoviTima);
        }

        // DELETE: api/OOADClanoviTimas1/5
        [ResponseType(typeof(OOADClanoviTima))]
        public IHttpActionResult DeleteOOADClanoviTima(int id)
        {
            OOADClanoviTima oOADClanoviTima = db.OOADClanoviTimas.Find(id);
            if (oOADClanoviTima == null)
            {
                return NotFound();
            }

            db.OOADClanoviTimas.Remove(oOADClanoviTima);
            db.SaveChanges();

            return Ok(oOADClanoviTima);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADClanoviTimaExists(int id)
        {
            return db.OOADClanoviTimas.Count(e => e.Korisnik == id) > 0;
        }
    }
}