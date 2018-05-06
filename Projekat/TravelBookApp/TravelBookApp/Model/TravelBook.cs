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
            Naziv = "TravelBook";
            Lokacija = "Bosanska 77";
            EmailAdresa = "travelBookInfo@hotmail.com";
            KontaktTelefon = "062/555-555";
            BankovniRacun = "1321000256000080"; //16 brojeva
            CijenaUsluge = 1000;
            CijenaIstaknutogPutovanja = 500;
            Agencije = new List<Agencija>();
            Korisnici = new List<Korisnik>();
            Putovanja = new List<Putovanje>();
            Destinacije = new List<Destinacija>();
            Hoteli = new List<Hotel>();
            Prevozi = new List<Prevoz>();
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
