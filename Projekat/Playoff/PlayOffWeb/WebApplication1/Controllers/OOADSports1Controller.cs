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
    public class OOADSports1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADSports1
        public IQueryable<OOADSport> GetOOADSports()
        {
            return db.OOADSports;
        }

        // GET: api/OOADSports1/5
        [ResponseType(typeof(OOADSport))]
        public IHttpActionResult GetOOADSport(int id)
        {
            OOADSport oOADSport = db.OOADSports.Find(id);
            if (oOADSport == null)
            {
                return NotFound();
            }

            return Ok(oOADSport);
        }

        // PUT: api/OOADSports1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADSport(int id, OOADSport oOADSport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADSport.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADSport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADSportExists(id))
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

        // POST: api/OOADSports1
        [ResponseType(typeof(OOADSport))]
        public IHttpActionResult PostOOADSport(OOADSport oOADSport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADSports.Add(oOADSport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADSportExists(oOADSport.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADSport.ID }, oOADSport);
        }

        // DELETE: api/OOADSports1/5
        [ResponseType(typeof(OOADSport))]
        public IHttpActionResult DeleteOOADSport(int id)
        {
            OOADSport oOADSport = db.OOADSports.Find(id);
            if (oOADSport == null)
            {
                return NotFound();
            }

            db.OOADSports.Remove(oOADSport);
            db.SaveChanges();

            return Ok(oOADSport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADSportExists(int id)
        {
            return db.OOADSports.Count(e => e.ID == id) > 0;
        }
    }
}