using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public enum VrstaPrevoza { autobus, avion};
    public class Prevoz
    {
        private String ime;
        private VrstaPrevoza vrstaPrevoza;
        private int maximalniKapacitet;
        private int kapacitet;
        private Double cijenaPoOsobi;

        public Prevoz(string ime, VrstaPrevoza vrstaPrevoza, int maximalniKapacitet, int kapacitet, double cijenaPoOsobi)
        {
            this.Ime = ime;
            this.VrstaPrevoza = vrstaPrevoza;
            this.MaximalniKapacitet = maximalniKapacitet;
            this.Kapacitet = kapacitet;
            this.CijenaPoOsobi = cijenaPoOsobi;
        }

        public string Ime { get => ime; set => ime = value; }
        public VrstaPrevoza VrstaPrevoza { get => vrstaPrevoza; set => vrstaPrevoza = value; }
        public int MaximalniKapacitet { get => maximalniKapacitet; set => maximalniKapacitet = value; }
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }
        public double CijenaPoOsobi { get => cijenaPoOsobi; set => cijenaPoOsobi = value; }
    }
}
