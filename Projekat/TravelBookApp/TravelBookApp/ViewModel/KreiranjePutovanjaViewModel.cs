using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.ViewModel
{
    public class KreiranjePutovanjaViewModel
    {
        public static DestinacijaViewModel destinacijaVM = new DestinacijaViewModel();
        public static HotelViewModel hotelVM = new HotelViewModel();

        public void kreirajPutovanje(DateTime datumPolaska, DateTime datumPovratka, int minimalniBrojPutnika, int maximalniBrojPutnika, string opisPutovanja, bool istaknutoPutovanje, int idAgencije, Destinacija infoDestinacije, Hotel infoHotela, Prevoz infoPrevoza, Double cijenaPutovanja)
        {
            Putovanje putovanje =  new Putovanje(datumPolaska, datumPovratka, minimalniBrojPutnika, maximalniBrojPutnika, opisPutovanja, istaknutoPutovanje, idAgencije, infoDestinacije, infoHotela, infoPrevoza, cijenaPutovanja);
            Globalna.nasaAgencija.Putovanja.Add(putovanje);

        }


        public void dodajNoviHotel(string ime, Image slikeHotela, int maximalniKapacitet, int kapacitet, Destinacija lokacija, double cijenaPoOsobi)
        {
            Hotel h = new Hotel(ime, slikeHotela, maximalniKapacitet, kapacitet, lokacija, cijenaPoOsobi); //moze fixna da ne dodajemo sve
            Globalna.nasaAgencija.Hoteli.Add(h);

        }

        public void dodajNovuDestinaciju(string naziv, String drzava, Kontinenti kontinent, Image slikeDestinacije)
        {
            Destinacija de = new Destinacija(naziv, drzava, kontinent, slikeDestinacije);
            Globalna.nasaAgencija.Destinacije.Add(de);

        }


        // mozda ove dvije dodat u PrevozViewModel???
        public void dodajListuBusPrevoza()
        {
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz ("Globus", VrstaPrevoza.autobus, 80,30, 50, "Pariz" ));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Centro", VrstaPrevoza.autobus, 150, 80, 100, "Prag"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("VanBus", VrstaPrevoza.autobus, 50, 30, 70, "Berlin"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 220, 70, 90, "Moskva"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 130, 45, 75, "Rim"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 100, 90, 60, "Barselona"));
        }

        public List<String> dajListuBusevaPoDestinacijiIKapacitetu(String destinacija, int kapacitet) // dodat
        {
            List<String> lista = new List<string>();
            foreach(Prevoz p in Globalna.nasaAgencija.Prevozi)
            {
                if (p.PrevozDestinacija.Equals(destinacija) && p.Kapacitet >= kapacitet) lista.Add(p.Ime);
            }
            return lista;
        }

        public List<String> dajListuHotelaPoDestinaciji(String destinacija)
        {
            return hotelVM.dajListuNazivaHotelaPoLokaciji(destinacija);
        }
    }
}
