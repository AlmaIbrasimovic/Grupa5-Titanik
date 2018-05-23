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
    public class DestinacijaAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/DestinacijaAzure
        public IQueryable<DestinacijaAzure> GetDestinacijaAzures()
        {
            return db.DestinacijaAzures;
        }

        // GET: api/DestinacijaAzure/5
        [ResponseType(typeof(DestinacijaAzure))]
        public async Task<IHttpActionResult> GetDestinacijaAzure(string id)
        {
            DestinacijaAzure destinacijaAzure = await db.DestinacijaAzures.FindAsync(id);
            if (destinacijaAzure == null)
            {
                return NotFound();
            }

            return Ok(destinacijaAzure);
        }

        // PUT: api/DestinacijaAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDestinacijaAzure(string id, DestinacijaAzure destinacijaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destinacijaAzure.id)
            {
                return BadRequest();
            }

            db.Entry(destinacijaAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinacijaAzureExists(id))
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

        // POST: api/DestinacijaAzure
        [ResponseType(typeof(DestinacijaAzure))]
        public async Task<IHttpActionResult> PostDestinacijaAzure(DestinacijaAzure destinacijaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DestinacijaAzures.Add(destinacijaAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinacijaAzureExists(destinacijaAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = destinacijaAzure.id }, destinacijaAzure);
        }

        // DELETE: api/DestinacijaAzure/5
        [ResponseType(typeof(DestinacijaAzure))]
        public async Task<IHttpActionResult> DeleteDestinacijaAzure(string id)
        {
            DestinacijaAzure destinacijaAzure = await db.DestinacijaAzures.FindAsync(id);
            if (destinacijaAzure == null)
            {
                return NotFound();
            }

            db.DestinacijaAzures.Remove(destinacijaAzure);
            await db.SaveChangesAsync();

            return Ok(destinacijaAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinacijaAzureExists(string id)
        {
            return db.DestinacijaAzures.Count(e => e.id == id) > 0;
        }
    }
}