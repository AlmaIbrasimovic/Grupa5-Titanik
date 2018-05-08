using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TravelBookApp.ViewModel;
using System.Data;
using System.Data.SqlClient;

using Windows.ApplicationModel.Core;
using TravelBookApp.Model;
using System.Collections.ObjectModel;

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
            if (Globalna.nasaAgencija.Agencije.Capacity == 0)
            {
                 Ucitaj();
            }
            
        }
        public void Ucitaj()
        {
            const string GetProductsQuery = "select u.username,u.password,u.id,o.naziv,o.jmbg,o.datum_rodjenja,o.email,o.id from uposlenici u, osobe o where u.osoba=o.id ";
            var agencije = new ObservableCollection<Agencija>();
            try
            {
                // Debug.WriteLine("Spajam sam na bazu");
                using (SqlConnection conn = new SqlConnection(App.konekcija))
                {
                    // Debug.WriteLine("Spojen sam na bazu");
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string Username = reader.GetString(0);
                                    string Password = reader.GetString(1);
                                    int id = reader.GetInt32(2);
                                    string naziv = reader.GetString(3);
                                    string jmbg = reader.GetString(4);
                                    DateTime datumRodjenja = reader.GetDateTime(5);
                                    string email = reader.GetString(6);
                                    int idOsobe = reader.GetInt32(7);

                                   // Globalna.nasaAgencija.Agencije.Add(Username, Password);
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
