using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
     
    public class HomeController : Controller
    {
        private TravelContext db = new TravelContext();
        static String error = "ok";
        public ActionResult Index()
        {
            Debug.Print(error);
            if(error != "ok") ModelState.AddModelError("pokazi", error);
            error = "ok";
            
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
            String rezultat = rezervacija(idPutovanja, rez.id);
            Debug.Print(rezultat + " to je rezultat");
            error = rezultat;
            if(rezultat == "ok") posalji(destinacija,rez.email); //validan email
            return RedirectToAction("Index");

        }

        public String rezervacija(String putovanje, String idKorisnika)
        {
            var query1 = from a in db.PutovanjeAzures
                        where a.id.Equals(putovanje)
                        select a;
            var rez1 = query1.FirstOrDefault();
            if (rez1.minBrojPutnika >= rez1.maxBrojPutnika - 1)
            {                
                return "Sva mjesta su popunjena!";
            }
            Debug.Print(rez1.minBrojPutnika + " broj max");
            var samoZaID = db.RezervisanaPutovanjaAzures.ToList();
            String id = samoZaID.Count.ToString();

            var query = from a in db.RezervisanaPutovanjaAzures
                        where a.idKorisnika.Equals(idKorisnika)
                        select a;

            List<RezervisanaPutovanjaAzure>  rez = query.ToList();
            List<PutovanjeAzure> putovanja = new List<PutovanjeAzure>();
            foreach(RezervisanaPutovanjaAzure re in rez)
            {
                var q = from k in db.PutovanjeAzures
                        where k.id.Equals(re.idPutovanja)
                        select k;
                putovanja.AddRange(q.ToList());
            }

           // Debug.Print(rez1.datumPovratka >=  + "");
            foreach (PutovanjeAzure p in putovanja)
            {
                if (rez1.datumPolaska <= p.datumPolaska && rez1.datumPovratka <= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if (rez1.datumPolaska >= p.datumPolaska && rez1.datumPolaska <= p.datumPovratka && rez1.datumPovratka >= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if(rez1.datumPolaska <= p.datumPolaska && rez1.datumPovratka >= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if(rez1.datumPolaska >= p.datumPolaska && rez1.datumPovratka <= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                
            }
            Debug.Print("doso do ovdeeeeee");
            RezervisanaPutovanjaAzure r = new RezervisanaPutovanjaAzure();
            r.idPutovanja = rez1.id;
            r.idKorisnika = idKorisnika; //id ne valja
            r.id = id; //bacit ce izuzetak ako je vec upisan taj broj u bazu jer je pk
            r.deleted = false;
            r.createdAt = DateTimeOffset.Now;
            r.updatedAt = DateTimeOffset.Now;
            rez1.minBrojPutnika = rez1.minBrojPutnika + 1;
            Debug.Print(rez1.minBrojPutnika + "  povecan ");
            db.RezervisanaPutovanjaAzures.Add(r);
            db.SaveChanges();
            return "ok";

        }

        public ActionResult About()
        {
            ViewBag.Message = "O agenciji";

            return View();
        }
        public ActionResult Contact()
        {
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