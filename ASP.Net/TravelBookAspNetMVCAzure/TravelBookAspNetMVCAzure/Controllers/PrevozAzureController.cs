using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
    public class PrevozAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/PrevozAzure
        public IQueryable<PrevozAzure> GetPrevozAzures()
        {
            return db.PrevozAzures;
        }

        // GET: api/PrevozAzure/5
        [ResponseType(typeof(PrevozAzure))]
        public async Task<IHttpActionResult> GetPrevozAzure(string id)
        {
            PrevozAzure prevozAzure = await db.PrevozAzures.FindAsync(id);
            if (prevozAzure == null)
            {
                return NotFound();
            }

            return Ok(prevozAzure);
        }

        // PUT: api/PrevozAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrevozAzure(string id, PrevozAzure prevozAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prevozAzure.id)
            {
                return BadRequest();
            }

            db.Entry(prevozAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrevozAzureExists(id))
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

        // POST: api/PrevozAzure
        [ResponseType(typeof(PrevozAzure))]
        public async Task<IHttpActionResult> PostPrevozAzure(PrevozAzure prevozAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrevozAzures.Add(prevozAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrevozAzureExists(prevozAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prevozAzure.id }, prevozAzure);
        }

        // DELETE: api/PrevozAzure/5
        [ResponseType(typeof(PrevozAzure))]
        public async Task<IHttpActionResult> DeletePrevozAzure(string id)
        {
            PrevozAzure prevozAzure = await db.PrevozAzures.FindAsync(id);
            if (prevozAzure == null)
            {
                return NotFound();
            }

            db.PrevozAzures.Remove(prevozAzure);
            await db.SaveChangesAsync();

            return Ok(prevozAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrevozAzureExists(string id)
        {
            return db.PrevozAzures.Count(e => e.id == id) > 0;
        }
    }
}