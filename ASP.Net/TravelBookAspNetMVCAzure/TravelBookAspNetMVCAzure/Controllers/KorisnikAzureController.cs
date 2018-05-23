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
    public class KorisnikAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/KorisnikAzure
        public IQueryable<KorisnikAzure> GetKorisnikAzures()
        {
            return db.KorisnikAzures;
        }

        // GET: api/KorisnikAzure/5
        [ResponseType(typeof(KorisnikAzure))]
        public async Task<IHttpActionResult> GetKorisnikAzure(string id)
        {
            KorisnikAzure korisnikAzure = await db.KorisnikAzures.FindAsync(id);
            if (korisnikAzure == null)
            {
                return NotFound();
            }

            return Ok(korisnikAzure);
        }

        // PUT: api/KorisnikAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKorisnikAzure(string id, KorisnikAzure korisnikAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnikAzure.id)
            {
                return BadRequest();
            }

            db.Entry(korisnikAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikAzureExists(id))
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

        // POST: api/KorisnikAzure
        [ResponseType(typeof(KorisnikAzure))]
        public async Task<IHttpActionResult> PostKorisnikAzure(KorisnikAzure korisnikAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KorisnikAzures.Add(korisnikAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KorisnikAzureExists(korisnikAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = korisnikAzure.id }, korisnikAzure);
        }

        // DELETE: api/KorisnikAzure/5
        [ResponseType(typeof(KorisnikAzure))]
        public async Task<IHttpActionResult> DeleteKorisnikAzure(string id)
        {
            KorisnikAzure korisnikAzure = await db.KorisnikAzures.FindAsync(id);
            if (korisnikAzure == null)
            {
                return NotFound();
            }

            db.KorisnikAzures.Remove(korisnikAzure);
            await db.SaveChangesAsync();

            return Ok(korisnikAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisnikAzureExists(string id)
        {
            return db.KorisnikAzures.Count(e => e.id == id) > 0;
        }
    }
}