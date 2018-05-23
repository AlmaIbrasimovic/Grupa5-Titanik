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
    public class KarticaAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/KarticaAzure
        public IQueryable<KarticaAzure> GetKarticaAzures()
        {
            return db.KarticaAzures;
        }

        // GET: api/KarticaAzure/5
        [ResponseType(typeof(KarticaAzure))]
        public async Task<IHttpActionResult> GetKarticaAzure(string id)
        {
            KarticaAzure karticaAzure = await db.KarticaAzures.FindAsync(id);
            if (karticaAzure == null)
            {
                return NotFound();
            }

            return Ok(karticaAzure);
        }

        // PUT: api/KarticaAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKarticaAzure(string id, KarticaAzure karticaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karticaAzure.id)
            {
                return BadRequest();
            }

            db.Entry(karticaAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KarticaAzureExists(id))
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

        // POST: api/KarticaAzure
        [ResponseType(typeof(KarticaAzure))]
        public async Task<IHttpActionResult> PostKarticaAzure(KarticaAzure karticaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KarticaAzures.Add(karticaAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KarticaAzureExists(karticaAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = karticaAzure.id }, karticaAzure);
        }

        // DELETE: api/KarticaAzure/5
        [ResponseType(typeof(KarticaAzure))]
        public async Task<IHttpActionResult> DeleteKarticaAzure(string id)
        {
            KarticaAzure karticaAzure = await db.KarticaAzures.FindAsync(id);
            if (karticaAzure == null)
            {
                return NotFound();
            }

            db.KarticaAzures.Remove(karticaAzure);
            await db.SaveChangesAsync();

            return Ok(karticaAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KarticaAzureExists(string id)
        {
            return db.KarticaAzures.Count(e => e.id == id) > 0;
        }
    }
}