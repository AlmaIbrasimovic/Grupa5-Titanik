using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.Model
{
    public class Hotel
    {
        private String ime;
        private Image slikeHotela;
        private int maximalniKapacitet;
        private int kapacitet;
        private Destinacija lokacija;
        private Double cijenaPoOsobi;

        public Hotel(string ime, Image slikeHotela, int maximalniKapacitet, int kapacitet, Destinacija lokacija, double cijenaPoOsobi)
        {
            this.Ime = ime;
            this.SlikeHotela = slikeHotela;
            this.MaximalniKapacitet = maximalniKapacitet;
            this.Kapacitet = kapacitet;
            this.Lokacija = lokacija;
            this.CijenaPoOsobi = cijenaPoOsobi;
        }

        public string Ime { get => ime; set => ime = value; }
        public Image SlikeHotela { get => slikeHotela; set => slikeHotela = value; }
        public int MaximalniKapacitet { get => maximalniKapacitet; set => maximalniKapacitet = value; }
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }
        public Destinacija Lokacija { get => lokacija; set => lokacija = value; }
        public double CijenaPoOsobi { get => cijenaPoOsobi; set => cijenaPoOsobi = value; }
    }
}
