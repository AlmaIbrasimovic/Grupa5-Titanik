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
    }
}
