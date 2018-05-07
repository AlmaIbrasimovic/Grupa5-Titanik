using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public enum VrstaKartice { VISA, MasterCard, AmericanExpress, Discover };
    public class Kartica
    {
        
        private VrstaKartice vrsta;
        private String datumIsteka;
        private String broj;
        private int csc;
        private int id;

        public Kartica() { }

        public Kartica(VrstaKartice vrstaKatice, String datumIstekaKartice, String brojK, int cscBroj)
        {
            id = Globalna.idSvihKartica++;
            Vrsta = vrstaKatice;
            DatumIsteka = datumIstekaKartice;
            Broj = brojK;
            Csc = cscBroj;
        }

        private VrstaKartice Vrsta { get => vrsta; set => vrsta = value; }
        public String DatumIsteka { get => datumIsteka; set => datumIsteka = value; }
        public string Broj { get => broj; set => broj = value; }
        public int Csc { get => csc; set => csc = value; }
        public int Id { get => id; }
    }
}
