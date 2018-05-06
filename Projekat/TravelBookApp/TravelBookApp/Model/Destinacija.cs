using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.Model
{
    public enum Kontinenti { Afrika, Antartika, Azija, Evropa, JuznaAmerika, SjevernaAmerika, Australija };

    public class Destinacija
    {
        private String naziv;
        private String drzava;
        private Kontinenti kontinent;
        private Image slikeDestinacije;

        public Destinacija(string naziv, String drzava, Kontinenti kontinent, Image slikeDestinacije)
        {
            Naziv = naziv;
            Drzava = drzava;
            Kontinent = kontinent;
            SlikeDestinacije = slikeDestinacije;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public Image SlikeDestinacije { get => slikeDestinacije; set => slikeDestinacije = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public Kontinenti Kontinent { get => kontinent; set => kontinent = value; }
    }
}
