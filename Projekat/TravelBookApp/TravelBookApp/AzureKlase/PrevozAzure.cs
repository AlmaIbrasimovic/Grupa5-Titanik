using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class PrevozAzure
    {
        public string id { get; set; }
        public string ime { get; set; }
        public string vrstaPrevoza { get; set; }
        public int maxKapacitet { get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public string idDestinacije { get; set; }

        public PrevozAzure() { }

        public PrevozAzure(string _id, string _ime, string _vrstaPrevoza, int _maxKapacitet, int _kapacitet, double _cijena, string _idDestinacije)
        {
            id = _id;
            ime = _ime;
            vrstaPrevoza = _vrstaPrevoza;
            maxKapacitet = _maxKapacitet;
            kapacitet = _kapacitet;
            cijena = _cijena;
            idDestinacije = _idDestinacije;
        }
    }
}
