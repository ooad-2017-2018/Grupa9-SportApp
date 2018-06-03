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
    public class OOADMecs1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADMecs1
        public IQueryable<OOADMec> GetOOADMecs()
        {
            return db.OOADMecs;
        }

        // GET: api/OOADMecs1/5
        [ResponseType(typeof(OOADMec))]
        public IHttpActionResult GetOOADMec(int id)
        {
            OOADMec oOADMec = db.OOADMecs.Find(id);
            if (oOADMec == null)
            {
                return NotFound();
            }

            return Ok(oOADMec);
        }

        // PUT: api/OOADMecs1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADMec(int id, OOADMec oOADMec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADMec.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADMec).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADMecExists(id))
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

        // POST: api/OOADMecs1
        [ResponseType(typeof(OOADMec))]
        public IHttpActionResult PostOOADMec(OOADMec oOADMec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADMecs.Add(oOADMec);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADMecExists(oOADMec.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADMec.ID }, oOADMec);
        }

        // DELETE: api/OOADMecs1/5
        [ResponseType(typeof(OOADMec))]
        public IHttpActionResult DeleteOOADMec(int id)
        {
            OOADMec oOADMec = db.OOADMecs.Find(id);
            if (oOADMec == null)
            {
                return NotFound();
            }

            db.OOADMecs.Remove(oOADMec);
            db.SaveChanges();

            return Ok(oOADMec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADMecExists(int id)
        {
            return db.OOADMecs.Count(e => e.ID == id) > 0;
        }
    }
}