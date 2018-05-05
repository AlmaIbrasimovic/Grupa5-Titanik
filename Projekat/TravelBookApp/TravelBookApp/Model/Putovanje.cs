using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class Putovanje
    {

        static int id = 0;
        private DateTime datumPolaska;
        private DateTime datumPovratka;
        private int minimalniBrojPutnika;
        private int maximalniBrojPutnika;
        private String opisPutovanja;
        private Boolean istaknutoPutovanje;
        private int idAgencije;
        private Destinacija infoDestinacije;
        private Hotel infoHotela;
        private Prevoz infoPrevoza;

        public Putovanje(DateTime datumPolaska, DateTime datumPovratka, int minimalniBrojPutnika, int maximalniBrojPutnika, string opisPutovanja, bool istaknutoPutovanje, int idAgencije, Destinacija infoDestinacije, Hotel infoHotela, Prevoz infoPrevoza)
        {
            id++;
            this.DatumPolaska = datumPolaska;
            this.DatumPovratka = datumPovratka;
            this.MinimalniBrojPutnika = minimalniBrojPutnika;
            this.MaximalniBrojPutnika = maximalniBrojPutnika;
            this.OpisPutovanja = opisPutovanja;
            this.IstaknutoPutovanje = istaknutoPutovanje;
            this.IdAgencije = idAgencije;
            this.InfoDestinacije = infoDestinacije;
            this.InfoHotela = infoHotela;
            this.InfoPrevoza = infoPrevoza;
        }

        public DateTime DatumPolaska { get => datumPolaska; set => datumPolaska = value; }
        public DateTime DatumPovratka { get => datumPovratka; set => datumPovratka = value; }
        public int MinimalniBrojPutnika { get => minimalniBrojPutnika; set => minimalniBrojPutnika = value; }
        public int MaximalniBrojPutnika { get => maximalniBrojPutnika; set => maximalniBrojPutnika = value; }
        public string OpisPutovanja { get => opisPutovanja; set => opisPutovanja = value; }
        public bool IstaknutoPutovanje { get => istaknutoPutovanje; set => istaknutoPutovanje = value; }
        public int IdAgencije { get => idAgencije; set => idAgencije = value; }
        public Destinacija InfoDestinacije { get => infoDestinacije; set => infoDestinacije = value; }
        public Hotel InfoHotela { get => infoHotela; set => infoHotela = value; }
        public Prevoz InfoPrevoza { get => infoPrevoza; set => infoPrevoza = value; }
    }
}
