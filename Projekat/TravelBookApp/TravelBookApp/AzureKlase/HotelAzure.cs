using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class HotelAzure
    {
        public string id { get; set; }
        public string ime { get; set; }
        public string slika { get; set; }
        public int maxKapacitet { get; set; }
        public int kapacitet { get; set; }
        public string idDestinacije { get; set; }
        public double cijena { get; set; }

        public HotelAzure() { }

        public HotelAzure(string _id, string _ime, string _slika, int _maxKapacitet, int _kapacitet, string _idDestinacije, double _cijena)
        {
            id = _id;
            ime = _ime;
            slika = _slika;
            maxKapacitet = _maxKapacitet;
            kapacitet = _kapacitet;
            idDestinacije = _idDestinacije;
            cijena = _cijena;
        }
    }
}
