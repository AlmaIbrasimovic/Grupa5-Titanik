using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class DestinacijaViewModel
    {
        public void dodajDestinaciju(string naziv, List<object> slikeDestinacije) {
            new Destinacija(naziv, slikeDestinacije);
        }
    }
}
