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
    public class OOADKorisnicis1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADKorisnicis1
        public IQueryable<OOADKorisnici> GetOOADKorisnicis()
        {
            return db.OOADKorisnicis;
        }

        // GET: api/OOADKorisnicis1/5
        [ResponseType(typeof(OOADKorisnici))]
        public IHttpActionResult GetOOADKorisnici(int id)
        {
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            if (oOADKorisnici == null)
            {
                return NotFound();
            }

            return Ok(oOADKorisnici);
        }

        // PUT: api/OOADKorisnicis1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADKorisnici(int id, OOADKorisnici oOADKorisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADKorisnici.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADKorisnici).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADKorisniciExists(id))
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

        // POST: api/OOADKorisnicis1
        [ResponseType(typeof(OOADKorisnici))]
        public IHttpActionResult PostOOADKorisnici(OOADKorisnici oOADKorisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADKorisnicis.Add(oOADKorisnici);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADKorisniciExists(oOADKorisnici.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADKorisnici.ID }, oOADKorisnici);
        }

        // DELETE: api/OOADKorisnicis1/5
        [ResponseType(typeof(OOADKorisnici))]
        public IHttpActionResult DeleteOOADKorisnici(int id)
        {
            OOADKorisnici oOADKorisnici = db.OOADKorisnicis.Find(id);
            if (oOADKorisnici == null)
            {
                return NotFound();
            }

            db.OOADKorisnicis.Remove(oOADKorisnici);
            db.SaveChanges();

            return Ok(oOADKorisnici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADKorisniciExists(int id)
        {
            return db.OOADKorisnicis.Count(e => e.ID == id) > 0;
        }
    }
}