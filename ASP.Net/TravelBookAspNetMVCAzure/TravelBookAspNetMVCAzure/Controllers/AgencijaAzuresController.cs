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
    public class AgencijaAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: AgencijaAzures
        public ActionResult Index()
        {
            return View(db.AgencijaAzures.ToList());
        }

        // GET: AgencijaAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
            if (agencijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(agencijaAzure);
        }

        // GET: AgencijaAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgencijaAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,idKartica,telefon,grad,lokacija,sifra,email")] AgencijaAzure agencijaAzure)
        {
            if (ModelState.IsValid)
            {
                db.AgencijaAzures.Add(agencijaAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencijaAzure);
        }

        // GET: AgencijaAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
            if (agencijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(agencijaAzure);
        }

        // POST: AgencijaAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,idKartica,telefon,grad,lokacija,sifra,email")] AgencijaAzure agencijaAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencijaAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencijaAzure);
        }

        // GET: AgencijaAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
            if (agencijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(agencijaAzure);
        }

        // POST: AgencijaAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
            db.AgencijaAzures.Remove(agencijaAzure);
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
