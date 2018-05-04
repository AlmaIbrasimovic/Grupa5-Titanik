using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public class Agencija : IPrint
    {
        static int id = 0;
        private String nazivAgencije;
        private Kartica podaciOBankovnomRacunu;
        private String kontaktTelefon;
        private String emailAdresa;
        private String lokacija;

        public Agencija(String naziv, Kartica kartica, String telefon, String email, String adresa)
        {
            NazivAgencije = naziv;
            PodaciOBankovnomRacunu = kartica;
            KontaktTelefon = telefon;
            EmailAdresa = email;
            Lokacija = adresa;
        }

        public string NazivAgencije { get => nazivAgencije; set => nazivAgencije = value; }
        public Kartica PodaciOBankovnomRacunu { get => podaciOBankovnomRacunu; set => podaciOBankovnomRacunu = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string EmailAdresa { get => emailAdresa; set => emailAdresa = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }

        public string IspisiString()
        {
            return string.Format("Naziv: {0}" + Environment.NewLine +
                                 "E-mail: {1}" + Environment.NewLine +
                                 "Kontakt telefon: {2}" + Environment.NewLine +
                                 "Adresa: {3}", NazivAgencije, EmailAdresa, KontaktTelefon, Lokacija);
        }


    }
}
