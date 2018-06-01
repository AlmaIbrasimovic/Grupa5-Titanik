using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TravelBookApp.ViewModel;
using System.Data;
using System.Data.SqlClient;

using Windows.ApplicationModel.Core;
using TravelBookApp.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TravelBookApp.AzureKlase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        static LoginViewModel l = new LoginViewModel();
      //  public String konekcija = "Server=tcp:travelbookserver.database.windows.net,1433;Initial Catalog=TravelBookDB;Persist Security Info=False;User ID=mujo;Password=Fata123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Prijava()
        {
           this.InitializeComponent();
           // upisiDummyPodatke(); samo pozvat kad je baza za hotele prevoze i destinacije prazna
            if (Globalna.nasaAgencija.Putovanja.Count == 0 && Globalna.nasaAgencija.Agencije.Count == 0) ucitajBazuUwp();
        


        }

        public void ucitajBazuUwp()
        {
            AgencijaAzure a = new AgencijaAzure();
            DestinacijaAzure d = new DestinacijaAzure();
            HotelAzure h = new HotelAzure();
            KarticaAzure k = new KarticaAzure();
            PrevozAzure l = new PrevozAzure();
            PutovanjeAzure p = new PutovanjeAzure();
            k.UcitajKartice();
            a.UcitajAgencije();
            d.UcitajDestinacije();
            h.UcitajHotele();
           
            l.UcitajPrevoze();
            p.UcitajPutovanja();
        }

        private void bPrijava_Click(object sender, RoutedEventArgs e)
        {
            if (l.prijaviAgenciju(tNaziv.Text, bSifra.Password.ToString()))
            {
              Frame.Navigate(typeof(PocetnaStranica));
                l.Poruka = new Windows.UI.Popups.MessageDialog("Putovanja: " + Globalna.nasaAgencija.Putovanja.Count + ", kartice: " + Globalna.nasaAgencija.Kartice.Count + ", agencije: " + Globalna.nasaAgencija.Agencije.Count + ", destinacije: " + Globalna.nasaAgencija.Destinacije.Count + ", hoteli: " + Globalna.nasaAgencija.Hoteli.Count + ", prevozi: " + Globalna.nasaAgencija.Prevozi.Count + "\n ");
                l.Poruka.ShowAsync();
            }
            else
            {
                l.Poruka = new Windows.UI.Popups.MessageDialog("Agencija ne postoji ili su podaci netačni.");
                l.Poruka.ShowAsync();
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistracijaAgencije));
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }


        public void upisiDummyPodatke()
        {
            //destinacije i hoteli
            Destinacija prva = new Destinacija("Sarajevo", "Bosna i Hercegovina", Kontinenti.Evropa);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            Hotel h = new Hotel("Radon Plaza", 600, 30, prva, 150);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Zagreb", "Hrvatska", Kontinenti.Evropa);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Evropa", 300, 100, prva, 100);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Tokio", "Japan", Kontinenti.Azija);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Hokaido Hotel", 500, 30, prva, 250);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Seul", "Južna Koreja", Kontinenti.Azija);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Husha Kusha", 200, 70, prva, 450);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Kairo", "Egipat", Kontinenti.Afrika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Mumija", 600, 530, prva, 250);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Adis Abeba", "Etiopija", Kontinenti.Afrika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Utopija", 400, 200, prva, 550);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Otava", "Kanada", Kontinenti.SjevernaAmerika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Hohol", 450, 100, prva, 650);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Rio de Janeiro", "Brazil", Kontinenti.JuznaAmerika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Fulon", 600, 400, prva, 1000);
            Globalna.nasaAgencija.Hoteli.Add(h);

            //dodavanje prevoza

            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 80, 30, 50, "Tokio"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Centro", VrstaPrevoza.autobus, 150, 80, 100, "Sarajevo"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("VanBus", VrstaPrevoza.autobus, 50, 30, 70, "Otava"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 220, 70, 90, "Kairo"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 130, 45, 75, "Zagreb"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 100, 90, 60, "Rio de Janeiro"));

            DestinacijaAzure d = new DestinacijaAzure();
            foreach (Destinacija des in Globalna.nasaAgencija.Destinacije) d.dodajDestinaciju(des);
            HotelAzure ho = new HotelAzure();
            foreach (Hotel hot in Globalna.nasaAgencija.Hoteli) ho.dodajHotel(hot);
            PrevozAzure pr = new PrevozAzure();
            foreach (Prevoz prev in Globalna.nasaAgencija.Prevozi) pr.dodajPrevoz(prev);

        }
    }
}
