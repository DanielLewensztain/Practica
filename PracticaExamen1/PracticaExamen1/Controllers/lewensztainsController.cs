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
using PracticaExamen1.Models;

namespace PracticaExamen1.Controllers
{
    public class lewensztainsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/lewensztains
        [Authorize]
        public IQueryable<lewensztain> Getlewensztains()
        {
            return db.lewensztains;
        }

        // GET: api/lewensztains/5
        [Authorize]
        [ResponseType(typeof(lewensztain))]
        public IHttpActionResult Getlewensztain(int id)
        {
            lewensztain lewensztain = db.lewensztains.Find(id);
            if (lewensztain == null)
            {
                return NotFound();
            }

            return Ok(lewensztain);
        }

        // PUT: api/lewensztains/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlewensztain(int id, lewensztain lewensztain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lewensztain.lewensztainID)
            {
                return BadRequest();
            }

            db.Entry(lewensztain).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lewensztainExists(id))
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

        // POST: api/lewensztains
        [Authorize]
        [ResponseType(typeof(lewensztain))]
        public IHttpActionResult Postlewensztain(lewensztain lewensztain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lewensztains.Add(lewensztain);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lewensztain.lewensztainID }, lewensztain);
        }

        // DELETE: api/lewensztains/5
        [Authorize]
        [ResponseType(typeof(lewensztain))]
        public IHttpActionResult Deletelewensztain(int id)
        {
            lewensztain lewensztain = db.lewensztains.Find(id);
            if (lewensztain == null)
            {
                return NotFound();
            }

            db.lewensztains.Remove(lewensztain);
            db.SaveChanges();

            return Ok(lewensztain);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool lewensztainExists(int id)
        {
            return db.lewensztains.Count(e => e.lewensztainID == id) > 0;
        }
    }
}