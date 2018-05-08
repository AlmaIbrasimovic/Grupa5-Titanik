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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        static LoginViewModel l = new LoginViewModel();
        public Prijava()
        {
            this.InitializeComponent();
            /*  if (Globalna.nasaAgencija.Agencije.Capacity == 0)
              {
                   Ucitaj();
              }*/
            Ucitaj();
            
        }
        public void Ucitaj()
        {
            const string GetProductsQuery = "SELECT id,naziv,idKartica,telefon,grad,lokacija,sifra,email FROM AgencijaAzure";
            var agencije = new ObservableCollection<Agencija>();
            try
            {
                // Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.konekcija))
                {
                 //   Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                           Debug.WriteLine("Spojen sam na bazu");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    
                                    string id = reader.GetString(0);
                                    string naziv = reader.GetString(1);
                                    string idKartica = reader.GetString(2);
                                    string telefon = reader.GetString(3);
                                    string grad = reader.GetString(4);
                                    string lokacija = reader.GetString(5);
                                    string sifra = reader.GetString(6);
                                    string email = reader.GetString(7);
                                    Kartica kartica = new Kartica(VrstaKartice.AmericanExpress, "55/88", "5", 123);
                                    Globalna.nasaAgencija.Agencije.Add(new Agencija(naziv, kartica, telefon, email, grad, lokacija, sifra));
                                    Debug.WriteLine("vel = ", Globalna.nasaAgencija.Agencije.Capacity.ToString());
                                }
                            }
                        }
                    }
                }        
            }
            catch (Exception eSql)
            {
                //    Debug.WriteLine(eSql);
                return;
            }
            return;
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
