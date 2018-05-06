using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
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
        private List<Agencija> agencije;
        private List<Putovanje> putovanja;
        private List<Destinacija> destinacije;
        private List<Hotel> hoteli;
        private List<Prevoz> prevozi;

        public TravelBook() {
            naziv = "TravelBook";
            lokacija = "Bosanska 77";
            emailAdresa = "travelBookInfo@hotmail.com";
            kontaktTelefon = "062/555-555";
            bankovniRacun = "1321000256000080"; //16 brojeva
            cijenaUsluge = 1000;
            cijenaIstaknutogPutovanja = 500;
            agencije = new List<Agencija>();
            korisnici = new List<Korisnik>();
            putovanja = new List<Putovanje>();
        }
                

        public string Naziv { get => naziv; set => naziv = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }
        public string EmailAdresa { get => emailAdresa; set => emailAdresa = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string BankovniRacun { get => bankovniRacun; set => bankovniRacun = value; }
        public double CijenaUsluge { get => cijenaUsluge; set => cijenaUsluge = value; }
        public double CijenaIstaknutogPutovanja { get => cijenaIstaknutogPutovanja; set => cijenaIstaknutogPutovanja = value; }
        public List<Korisnik> Korisnici { get => korisnici; set => korisnici = value; }
        public List<Putovanje> Putovanja { get => putovanja; set => putovanja = value; }
        public List<Agencija> Agencije { get => agencije; set => agencije = value; }
        public List<Destinacija> Destinacije { get => destinacije; set => destinacije = value; }
        public List<Hotel> Hoteli { get => hoteli; set => hoteli = value; }
        public List<Prevoz> Prevozi { get => prevozi; set => prevozi = value; }
    }
}
