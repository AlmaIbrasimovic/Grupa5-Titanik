using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelBookApp.ViewModel;
using TravelBookApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaAgencije : Page
    {
        static RegistracijaViewModel r = new RegistracijaViewModel();
        public RegistracijaAgencije()
        {
            this.InitializeComponent();

            tTipKartice.Items.Add(VrstaKartice.VISA);
            tTipKartice.Items.Add(VrstaKartice.MasterCard);
            tTipKartice.Items.Add(VrstaKartice.AmericanExpress);
            tTipKartice.Items.Add(VrstaKartice.Discover);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Prijava));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            Kartica nova = new Kartica((VrstaKartice)tTipKartice.SelectedItem, tDatumIsteka.Text, tBrojKartice.Text, Convert.ToInt32(tCSC.Text));
            if (tSifra.Password.ToString().Equals(tSifraPonovo.Password.ToString())) { 
            r.registrujAgneciju(tNaziv.Text, nova, tTelefon.Text, tMail.Text, tGrad.Text, tAdresa.Text, tSifra.Password.ToString());
                Frame.Navigate(typeof(Prijava));
            }
            else
            {
                r.Poruka = new MessageDialog("Pogresna sifra! Unesite ponovo.");
                r.Poruka.ShowAsync();
            }
        }

        private void tTipKartice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tDatumIsteka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tCSC_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
