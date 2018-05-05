using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public enum VrstaKartice { VISA, MasterCard }; // dodat 
    public class Kartica
    {
        
        private VrstaKartice vrsta;
        private DateTime datumIsteka;
        private String broj;
        private int csc;

        public Kartica(VrstaKartice vrstaKatice, DateTime datumIstekaKartice, String brojK, int cscBroj)
        {
            vrsta = vrstaKatice;
            datumIsteka = datumIstekaKartice;
            broj = brojK;
            csc = cscBroj;
        }

        private VrstaKartice Vrsta { get => vrsta; set => vrsta = value; }
        public DateTime DatumIsteka { get => datumIsteka; set => datumIsteka = value; }
        public string Broj { get => broj; set => broj = value; }
        public int Csc { get => csc; set => csc = value; }
    }
}
