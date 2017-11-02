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
using NobelApi.Models;

namespace NobelApi.Controllers
{
    public class LaureadoIndividuosController : ApiController
    {
        private NobelEntities db = new NobelEntities();

        // GET: api/LaureadoIndividuos
        public IQueryable<LaureadoIndividuo> GetLaureadoIndividuo()
        {
            return db.LaureadoIndividuo;
        }

        // GET: api/LaureadoIndividuos/5
        [ResponseType(typeof(LaureadoIndividuo))]
        public IHttpActionResult GetLaureadoIndividuo(int id)
        {
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            if (laureadoIndividuo == null)
            {
                return NotFound();
            }

            return Ok(laureadoIndividuo);
        }

        // PUT: api/LaureadoIndividuos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaureadoIndividuo(int id, LaureadoIndividuo laureadoIndividuo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laureadoIndividuo.LaureadoId)
            {
                return BadRequest();
            }

            db.Entry(laureadoIndividuo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaureadoIndividuoExists(id))
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

        // POST: api/LaureadoIndividuos
        [ResponseType(typeof(LaureadoIndividuo))]
        public IHttpActionResult PostLaureadoIndividuo(LaureadoIndividuo laureadoIndividuo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LaureadoIndividuo.Add(laureadoIndividuo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LaureadoIndividuoExists(laureadoIndividuo.LaureadoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = laureadoIndividuo.LaureadoId }, laureadoIndividuo);
        }

        // DELETE: api/LaureadoIndividuos/5
        [ResponseType(typeof(LaureadoIndividuo))]
        public IHttpActionResult DeleteLaureadoIndividuo(int id)
        {
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            if (laureadoIndividuo == null)
            {
                return NotFound();
            }

            db.LaureadoIndividuo.Remove(laureadoIndividuo);
            db.SaveChanges();

            return Ok(laureadoIndividuo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaureadoIndividuoExists(int id)
        {
            return db.LaureadoIndividuo.Count(e => e.LaureadoId == id) > 0;
        }
    }
}