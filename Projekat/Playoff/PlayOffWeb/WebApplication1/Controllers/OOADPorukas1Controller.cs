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
    public class OOADPorukas1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADPorukas1
        public IQueryable<OOADPoruka> GetOOADPorukas()
        {
            return db.OOADPorukas;
        }

        // GET: api/OOADPorukas1/5
        [ResponseType(typeof(OOADPoruka))]
        public IHttpActionResult GetOOADPoruka(int id)
        {
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            if (oOADPoruka == null)
            {
                return NotFound();
            }

            return Ok(oOADPoruka);
        }

        // PUT: api/OOADPorukas1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADPoruka(int id, OOADPoruka oOADPoruka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADPoruka.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADPoruka).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADPorukaExists(id))
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

        // POST: api/OOADPorukas1
        [ResponseType(typeof(OOADPoruka))]
        public IHttpActionResult PostOOADPoruka(OOADPoruka oOADPoruka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADPorukas.Add(oOADPoruka);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADPorukaExists(oOADPoruka.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADPoruka.ID }, oOADPoruka);
        }

        // DELETE: api/OOADPorukas1/5
        [ResponseType(typeof(OOADPoruka))]
        public IHttpActionResult DeleteOOADPoruka(int id)
        {
            OOADPoruka oOADPoruka = db.OOADPorukas.Find(id);
            if (oOADPoruka == null)
            {
                return NotFound();
            }

            db.OOADPorukas.Remove(oOADPoruka);
            db.SaveChanges();

            return Ok(oOADPoruka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADPorukaExists(int id)
        {
            return db.OOADPorukas.Count(e => e.ID == id) > 0;
        }
    }
}