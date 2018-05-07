using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.AzureKlase
{
    public class KarticaAzure
    {
        public String id { get; set; }
        public String vrstaKartice { get; set; }
        public String datumIsteka { get; set; }
        public String broj { get; set; }
        public int csc { get; set; }

        public KarticaAzure() { }
        public KarticaAzure(String _id, String _vrstaKartice, String _datumIsteka, String _broj, int _csc)
        {
            id = _id;
            vrstaKartice = _vrstaKartice;
            datumIsteka = _datumIsteka;
            broj = _broj;
            csc = _csc;
        }
    }
}
