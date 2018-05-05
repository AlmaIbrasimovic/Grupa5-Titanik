using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class KreiranjePutovanjaViewModel
    {
        public void kreirajPutovanje(DateTime datumPolaska, DateTime datumPovratka, int minimalniBrojPutnika, int maximalniBrojPutnika, string opisPutovanja, bool istaknutoPutovanje, int idAgencije, Destinacija infoDestinacije, Hotel infoHotela, Prevoz infoPrevoza) {
            new Putovanje(datumPolaska, datumPovratka, minimalniBrojPutnika, maximalniBrojPutnika, opisPutovanja, istaknutoPutovanje, idAgencije, infoDestinacije, infoHotela, infoPrevoza);
        }
    }
}
