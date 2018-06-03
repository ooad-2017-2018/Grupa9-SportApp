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
    public class OOADNaziviPozicijas1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADNaziviPozicijas1
        public IQueryable<OOADNaziviPozicija> GetOOADNaziviPozicijas()
        {
            return db.OOADNaziviPozicijas;
        }

        // GET: api/OOADNaziviPozicijas1/5
        [ResponseType(typeof(OOADNaziviPozicija))]
        public IHttpActionResult GetOOADNaziviPozicija(int id)
        {
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            if (oOADNaziviPozicija == null)
            {
                return NotFound();
            }

            return Ok(oOADNaziviPozicija);
        }

        // PUT: api/OOADNaziviPozicijas1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADNaziviPozicija(int id, OOADNaziviPozicija oOADNaziviPozicija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADNaziviPozicija.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADNaziviPozicija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADNaziviPozicijaExists(id))
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

        // POST: api/OOADNaziviPozicijas1
        [ResponseType(typeof(OOADNaziviPozicija))]
        public IHttpActionResult PostOOADNaziviPozicija(OOADNaziviPozicija oOADNaziviPozicija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADNaziviPozicijas.Add(oOADNaziviPozicija);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADNaziviPozicijaExists(oOADNaziviPozicija.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADNaziviPozicija.ID }, oOADNaziviPozicija);
        }

        // DELETE: api/OOADNaziviPozicijas1/5
        [ResponseType(typeof(OOADNaziviPozicija))]
        public IHttpActionResult DeleteOOADNaziviPozicija(int id)
        {
            OOADNaziviPozicija oOADNaziviPozicija = db.OOADNaziviPozicijas.Find(id);
            if (oOADNaziviPozicija == null)
            {
                return NotFound();
            }

            db.OOADNaziviPozicijas.Remove(oOADNaziviPozicija);
            db.SaveChanges();

            return Ok(oOADNaziviPozicija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADNaziviPozicijaExists(int id)
        {
            return db.OOADNaziviPozicijas.Count(e => e.ID == id) > 0;
        }
    }
}