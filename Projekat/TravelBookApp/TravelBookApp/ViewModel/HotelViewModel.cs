using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class HotelViewModel
    {
        public void dodajHotel(string ime, List<object> slikeHotela, int maximalniKapacitet, int kapacitet, Destinacija lokacija, double cijenaPoOsobi) {
            new Hotel(ime, slikeHotela, maximalniKapacitet, kapacitet, lokacija, cijenaPoOsobi);
        }
    }
}
