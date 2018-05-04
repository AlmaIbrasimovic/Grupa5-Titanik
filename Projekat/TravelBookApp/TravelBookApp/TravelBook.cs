using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public class TravelBook
    {
        private String naziv;
        private String lokacija;
        private String emailAdresa;
        private String kontaktTelefon;
        private String bankovniRacun;
        private Double cijenaUsluge;
        private Double cijenaIstaknutogPutovanja;
        private List<Korisnik> korisnici;

        public TravelBook() {
            naziv = "TravelBook";
            lokacija = "Hamdije Čemerlića 77";
            emailAdresa = "travelBookInfo@hotmail.com";
            kontaktTelefon = "062/555-555";
            bankovniRacun = "1321000256000080"; //16 brojeva
            cijenaUsluge = 1000;
            cijenaIstaknutogPutovanja = 500;
            korisnici = new List<Korisnik>();
        }
                

        public string Naziv { get => naziv; set => naziv = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }
        public string EmailAdresa { get => emailAdresa; set => emailAdresa = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string BankovniRacun { get => bankovniRacun; set => bankovniRacun = value; }
        public double CijenaUsluge { get => cijenaUsluge; set => cijenaUsluge = value; }
        public double CijenaIstaknutogPutovanja { get => cijenaIstaknutogPutovanja; set => cijenaIstaknutogPutovanja = value; }
        public List<Korisnik> Korisnici { get => korisnici; set => korisnici = value; }
    }
}
