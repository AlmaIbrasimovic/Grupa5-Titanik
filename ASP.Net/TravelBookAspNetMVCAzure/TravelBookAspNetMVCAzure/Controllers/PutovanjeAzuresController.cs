using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
    public class PutovanjeAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: PutovanjeAzures
        public ActionResult Index()
        {
            return View(db.PutovanjeAzures.ToList());
        }

        // GET: PutovanjeAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PutovanjeAzure putovanjeAzure = db.PutovanjeAzures.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        // GET: PutovanjeAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PutovanjeAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,datumPolaska,datumPovratka,minBrojPutnika,maxBrojPutnika,opisPutovanja,istaknuto,idAgencije,idDestinacije,idHotela,idPrevoz,cijena")] PutovanjeAzure putovanjeAzure)
        {
            if (ModelState.IsValid)
            {
                db.PutovanjeAzures.Add(putovanjeAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(putovanjeAzure);
        }

        // GET: PutovanjeAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PutovanjeAzure putovanjeAzure = db.PutovanjeAzures.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        // POST: PutovanjeAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,datumPolaska,datumPovratka,minBrojPutnika,maxBrojPutnika,opisPutovanja,istaknuto,idAgencije,idDestinacije,idHotela,idPrevoz,cijena")] PutovanjeAzure putovanjeAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(putovanjeAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(putovanjeAzure);
        }

        // GET: PutovanjeAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PutovanjeAzure putovanjeAzure = db.PutovanjeAzures.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        // POST: PutovanjeAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PutovanjeAzure putovanjeAzure = db.PutovanjeAzures.Find(id);
            db.PutovanjeAzures.Remove(putovanjeAzure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
