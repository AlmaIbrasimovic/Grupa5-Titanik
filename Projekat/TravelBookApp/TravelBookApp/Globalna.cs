using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp
{
    public static class Globalna
    {
        public static TravelBook nasaAgencija = new TravelBook();
        public static int prijavljenaAgencijaId = 0;
        public static bool trenutnaPutovanja = true;
    }
}
