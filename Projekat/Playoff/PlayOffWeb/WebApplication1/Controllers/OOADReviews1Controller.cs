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
    public class OOADReviews1Controller : ApiController
    {
        private PlayoffM db = new PlayoffM();

        // GET: api/OOADReviews1
        public IQueryable<OOADReview> GetOOADReviews()
        {
            return db.OOADReviews;
        }

        // GET: api/OOADReviews1/5
        [ResponseType(typeof(OOADReview))]
        public IHttpActionResult GetOOADReview(int id)
        {
            OOADReview oOADReview = db.OOADReviews.Find(id);
            if (oOADReview == null)
            {
                return NotFound();
            }

            return Ok(oOADReview);
        }

        // PUT: api/OOADReviews1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOOADReview(int id, OOADReview oOADReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oOADReview.ID)
            {
                return BadRequest();
            }

            db.Entry(oOADReview).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OOADReviewExists(id))
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

        // POST: api/OOADReviews1
        [ResponseType(typeof(OOADReview))]
        public IHttpActionResult PostOOADReview(OOADReview oOADReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OOADReviews.Add(oOADReview);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OOADReviewExists(oOADReview.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oOADReview.ID }, oOADReview);
        }

        // DELETE: api/OOADReviews1/5
        [ResponseType(typeof(OOADReview))]
        public IHttpActionResult DeleteOOADReview(int id)
        {
            OOADReview oOADReview = db.OOADReviews.Find(id);
            if (oOADReview == null)
            {
                return NotFound();
            }

            db.OOADReviews.Remove(oOADReview);
            db.SaveChanges();

            return Ok(oOADReview);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OOADReviewExists(int id)
        {
            return db.OOADReviews.Count(e => e.ID == id) > 0;
        }
    }
}