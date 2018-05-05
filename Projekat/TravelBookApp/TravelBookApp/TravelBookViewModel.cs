using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public class TravelBookViewModel
    {
        public List<Putovanje> prikaziSvaPutovanja() {
            List<Putovanje> svaPutovanja = new List<Putovanje>();

            return svaPutovanja;
        }
        public List<Korisnik> prikaziSveKorisnike() {
            List<Korisnik> sviKorisnici = new List<Korisnik>();

            return sviKorisnici;
        }
        public List<Agencija> prikaziSveAgencije() {
            List<Agencija> sveAgencije = new List<Agencija>();

            return sveAgencije;
        }
    }
}
