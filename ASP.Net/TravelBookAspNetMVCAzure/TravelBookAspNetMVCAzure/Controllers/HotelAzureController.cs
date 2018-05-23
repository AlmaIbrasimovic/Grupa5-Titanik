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
    public class HotelAzureController : ApiController
    {
        private TravelBookModel db = new TravelBookModel();

        // GET: api/HotelAzure
        public IQueryable<HotelAzure> GetHotelAzures()
        {
            return db.HotelAzures;
        }

        // GET: api/HotelAzure/5
        [ResponseType(typeof(HotelAzure))]
        public async Task<IHttpActionResult> GetHotelAzure(string id)
        {
            HotelAzure hotelAzure = await db.HotelAzures.FindAsync(id);
            if (hotelAzure == null)
            {
                return NotFound();
            }

            return Ok(hotelAzure);
        }

        // PUT: api/HotelAzure/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHotelAzure(string id, HotelAzure hotelAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelAzure.id)
            {
                return BadRequest();
            }

            db.Entry(hotelAzure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAzureExists(id))
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

        // POST: api/HotelAzure
        [ResponseType(typeof(HotelAzure))]
        public async Task<IHttpActionResult> PostHotelAzure(HotelAzure hotelAzure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelAzures.Add(hotelAzure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelAzureExists(hotelAzure.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotelAzure.id }, hotelAzure);
        }

        // DELETE: api/HotelAzure/5
        [ResponseType(typeof(HotelAzure))]
        public async Task<IHttpActionResult> DeleteHotelAzure(string id)
        {
            HotelAzure hotelAzure = await db.HotelAzures.FindAsync(id);
            if (hotelAzure == null)
            {
                return NotFound();
            }

            db.HotelAzures.Remove(hotelAzure);
            await db.SaveChangesAsync();

            return Ok(hotelAzure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelAzureExists(string id)
        {
            return db.HotelAzures.Count(e => e.id == id) > 0;
        }
    }
}