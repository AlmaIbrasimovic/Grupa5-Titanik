using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class AgencijaAzure
    {
        public String id { get; set; }
        public String naziv { get; set; }
        public String idKartica { get; set; }
        public String telefon { get; set; }
        public String grad { get; set; }
        public String lokacija { get; set; }
        public String sifra { get; set; }

        public AgencijaAzure() { }
        public AgencijaAzure(String _id, String _naziv, String _idKartica, String _telefon, String _grad, String _lokacija, String _sifra)
        {
            id = _id;
            naziv = _naziv;
            idKartica = _idKartica;
            telefon = _telefon;
            grad = _grad;
            lokacija = _lokacija;
            sifra = _sifra;
        }
    }
}