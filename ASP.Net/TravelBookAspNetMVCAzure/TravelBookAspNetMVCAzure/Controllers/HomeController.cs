using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
     
    public class HomeController : Controller
    {
        private TravelContext db = new TravelContext();
        public ActionResult Index()
        {
            var model = db.PutovanjeAzures.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "O agenciji";

            return View();
        }

        public string funkcija (string id)
        {
            var kontroler = new DestinacijaAzuresController();
            return kontroler.vratiIme(id);
        }
    }
}