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
    public class RezervisanaPutovanjaAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/RezervisanaPutovanjaAzure
        public IQueryable<RezervisanaPutovanjaAzure> GetRezervisanaPutovanjaAzures()
        {
            return db.RezervisanaPutovanjaAzures;
        }

        // GET: api/RezervisanaPutovanjaAzure/5
        [ResponseType(typeof(RezervisanaPutovanjaAzure))]
        public async Task<IHttpActionResult> GetRezervisanaPutovanjaAzure(string id)
        {
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = await db.RezervisanaPutovanjaAzures.FindAsync(id);
            if (rezervisanaPutovanjaAzure == null)
            {
                return NotFound();
            }

            return Ok(rezervisanaPutovanjaAzure);
        }

        // PUT: api/RezervisanaPutovanjaAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRezervisanaPutovanjaAzure(string id, RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rezervisanaPutovanjaAzure.id)
            {
                return BadRequest();
            }

            db.Entry(rezervisanaPutovanjaAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervisanaPutovanjaAzureExists(id))
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

        // POST: api/RezervisanaPutovanjaAzure
        [ResponseType(typeof(RezervisanaPutovanjaAzure))]
        public async Task<IHttpActionResult> PostRezervisanaPutovanjaAzure(RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RezervisanaPutovanjaAzures.Add(rezervisanaPutovanjaAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RezervisanaPutovanjaAzureExists(rezervisanaPutovanjaAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rezervisanaPutovanjaAzure.id }, rezervisanaPutovanjaAzure);
        }

        // DELETE: api/RezervisanaPutovanjaAzure/5
        [ResponseType(typeof(RezervisanaPutovanjaAzure))]
        public async Task<IHttpActionResult> DeleteRezervisanaPutovanjaAzure(string id)
        {
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = await db.RezervisanaPutovanjaAzures.FindAsync(id);
            if (rezervisanaPutovanjaAzure == null)
            {
                return NotFound();
            }

            db.RezervisanaPutovanjaAzures.Remove(rezervisanaPutovanjaAzure);
            await db.SaveChangesAsync();

            return Ok(rezervisanaPutovanjaAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RezervisanaPutovanjaAzureExists(string id)
        {
            return db.RezervisanaPutovanjaAzures.Count(e => e.id == id) > 0;
        }
    }
}