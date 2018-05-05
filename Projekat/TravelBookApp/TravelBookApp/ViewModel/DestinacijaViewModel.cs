using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp
{
    public class DestinacijaViewModel
    {
        public void dodajDestinaciju(string naziv, List<object> slikeDestinacije) {
            new Destinacija(naziv, slikeDestinacije);
        }
    }
}
