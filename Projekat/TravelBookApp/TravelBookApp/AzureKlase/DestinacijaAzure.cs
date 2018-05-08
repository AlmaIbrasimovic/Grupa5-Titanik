using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class DestinacijaAzure
    {
        public String id { get; set; }
        public String naziv { get; set; }
        public String drzava { get; set; }
        public String kontinent { get; set; }
        public String slika { get; set; }

        public DestinacijaAzure() { }
        public DestinacijaAzure(String _id, String _naziv, String _drzava, String _kontinent, String _slika = "")
        {
            id = _id;
            naziv = _naziv;
            drzava = _drzava;
            kontinent = _kontinent;
            slika = _slika;
        }
    }
}