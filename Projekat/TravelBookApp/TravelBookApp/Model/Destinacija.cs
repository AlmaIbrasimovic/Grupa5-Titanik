using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class Destinacija
    {
        private String naziv;
        private List<Object> slikeDestinacije;

        public Destinacija(string naziv, List<object> slikeDestinacije)
        {
            this.Naziv = naziv;
            this.SlikeDestinacije = slikeDestinacije;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public List<object> SlikeDestinacije { get => slikeDestinacije; set => slikeDestinacije = value; }
    }
}
