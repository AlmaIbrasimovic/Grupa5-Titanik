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
    public class PutovanjeAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/PutovanjeAzure
        public IQueryable<PutovanjeAzure> GetPutovanjeAzures()
        {
            return db.PutovanjeAzures;
        }

        // GET: api/PutovanjeAzure/5
        [ResponseType(typeof(PutovanjeAzure))]
        public async Task<IHttpActionResult> GetPutovanjeAzure(string id)
        {
            PutovanjeAzure putovanjeAzure = await db.PutovanjeAzures.FindAsync(id);
            if (putovanjeAzure == null)
            {
                return NotFound();
            }

            return Ok(putovanjeAzure);
        }

        // PUT: api/PutovanjeAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPutovanjeAzure(string id, PutovanjeAzure putovanjeAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != putovanjeAzure.id)
            {
                return BadRequest();
            }

            db.Entry(putovanjeAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PutovanjeAzureExists(id))
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

        // POST: api/PutovanjeAzure
        [ResponseType(typeof(PutovanjeAzure))]
        public async Task<IHttpActionResult> PostPutovanjeAzure(PutovanjeAzure putovanjeAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PutovanjeAzures.Add(putovanjeAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PutovanjeAzureExists(putovanjeAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = putovanjeAzure.id }, putovanjeAzure);
        }

        // DELETE: api/PutovanjeAzure/5
        [ResponseType(typeof(PutovanjeAzure))]
        public async Task<IHttpActionResult> DeletePutovanjeAzure(string id)
        {
            PutovanjeAzure putovanjeAzure = await db.PutovanjeAzures.FindAsync(id);
            if (putovanjeAzure == null)
            {
                return NotFound();
            }

            db.PutovanjeAzures.Remove(putovanjeAzure);
            await db.SaveChangesAsync();

            return Ok(putovanjeAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PutovanjeAzureExists(string id)
        {
            return db.PutovanjeAzures.Count(e => e.id == id) > 0;
        }
    }
}