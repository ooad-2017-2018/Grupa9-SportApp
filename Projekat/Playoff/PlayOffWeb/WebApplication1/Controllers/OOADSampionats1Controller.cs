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
    public class OOADSampionats1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADSampionats1
        public IQueryable<OOADSampionat> GetOOADSampionats()
        {
            return db.OOADSampionats;
        }

        // GET: api/OOADSampionats1/5
        [ResponseType(typeof(OOADSampionat))]
        public IHttpActionResult GetOOADSampionat(int id)
        {
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            if (oOADSampionat == null)
            {
                return NotFound();
            }

            return Ok(oOADSampionat);
        }

        // PUT: api/OOADSampionats1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADSampionat(int id, OOADSampionat oOADSampionat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADSampionat.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADSampionat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADSampionatExists(id))
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

        // POST: api/OOADSampionats1
        [ResponseType(typeof(OOADSampionat))]
        public IHttpActionResult PostOOADSampionat(OOADSampionat oOADSampionat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADSampionats.Add(oOADSampionat);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADSampionatExists(oOADSampionat.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADSampionat.ID }, oOADSampionat);
        }

        // DELETE: api/OOADSampionats1/5
        [ResponseType(typeof(OOADSampionat))]
        public IHttpActionResult DeleteOOADSampionat(int id)
        {
            OOADSampionat oOADSampionat = db.OOADSampionats.Find(id);
            if (oOADSampionat == null)
            {
                return NotFound();
            }

            db.OOADSampionats.Remove(oOADSampionat);
            db.SaveChanges();

            return Ok(oOADSampionat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADSampionatExists(int id)
        {
            return db.OOADSampionats.Count(e => e.ID == id) > 0;
        }
    }
}