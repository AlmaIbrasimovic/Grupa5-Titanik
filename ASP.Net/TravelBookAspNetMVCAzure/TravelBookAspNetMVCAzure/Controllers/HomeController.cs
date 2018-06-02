using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public ActionResult PosaljiEmail(String destinacija,String ime,String idPutovanja)
        {
          
            var query = from a in db.KorisnikAzures
                        where a.ime.Equals(ime)
                        select a;
            var rez = query.FirstOrDefault();
            Debug.Print(rez.email+" "+destinacija+" "+idPutovanja);
            RezervisanaPutovanjaAzure r = new RezervisanaPutovanjaAzure();
            r.idPutovanja = idPutovanja;
            r.idKorisnika = rez.id; //id ne valja
            r.id = "223"; //bacit ce izuzetak ako je vec upisan taj broj u bazu jer je pk
            r.deleted = false;
            r.createdAt = DateTimeOffset.Now;
            r.updatedAt = DateTimeOffset.Now;
            db.RezervisanaPutovanjaAzures.Add(r);
            db.SaveChanges();
            posalji(destinacija,rez.email); //validan email
            return RedirectToAction("Index");

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

        public void posalji(String destinacija,String email)
        {
            Debug.Print("tu");
            MailMessage mail = new MailMessage();
            mail.To.Add("zlatakaric@hotmail.com");
            //mail.To.Add("amit_jain_online@yahoo.com");
            mail.From = new MailAddress("travelbookTB@gmail.com");
            mail.Subject = "TravelBook";
            string Body = "Uspješno ste rezervisali Vaše putovanje za "+destinacija;
            mail.Body = Body;
            
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential("travelbookTB@gmail.com", "sifra123");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
         
            Debug.Print("tu1");
        }
    }
}