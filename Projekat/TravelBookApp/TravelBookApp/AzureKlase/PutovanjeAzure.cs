using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class PutovanjeAzure
    {
        public string id { get; set; }
        public DateTime datumPolaska { get; set; }
        public DateTime datumPovratka { get; set; }
        public int minBrojPutnika { get; set; }
        public int maxBrojPutnika { get; set; }
        public string opisPutovanja { get; set; }
        public Boolean istaknuto { get; set; }
        public string idAgencije { get; set; }
        public string idHotela { get; set; }
        public string idPrevoz { get; set; }

        public Double cijena { get; set; }
        
        public PutovanjeAzure() { }

        public PutovanjeAzure(string id, DateTime datumPolaska, DateTime datumPovratka, int minBrojPutnika, int maxBrojPutnika, string opisPutovanja, bool istaknuto, string idAgencije, string idHotela, string idPrevoz, Double cijena)
        {
            this.id = id;
            this.datumPolaska = datumPolaska;
            this.datumPovratka = datumPovratka;
            this.minBrojPutnika = minBrojPutnika;
            this.maxBrojPutnika = maxBrojPutnika;
            this.opisPutovanja = opisPutovanja;
            this.istaknuto = istaknuto;
            this.idAgencije = idAgencije;
            this.idHotela = idHotela;
            this.idPrevoz = idPrevoz;
            this.cijena = cijena;
        }
    }
}
