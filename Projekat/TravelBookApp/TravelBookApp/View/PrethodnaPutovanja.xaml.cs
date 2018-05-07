using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelBookApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrethodnaPutovanja : Page
    {
        public PrethodnaPutovanja()
        {
            this.InitializeComponent();

            foreach (Putovanje p in Globalna.nasaAgencija.Putovanja)
            {
                if (p.IdAgencije == Globalna.prijavljenaAgencijaId)
                {

                    if (Globalna.trenutnaPutovanja)
                    {
                        if (DateTime.Now <= p.DatumPovratka)
                            comboPutovanja.Items.Add(p.InfoDestinacije.Naziv + " " + Convert.ToString(p.DatumPolaska) + "-" + Convert.ToString(p.DatumPovratka));
                    }
                    else
                    {
                        if (p.DatumPovratka < DateTime.Now)
                            comboPutovanja.Items.Add(p.InfoDestinacije.Naziv + " " + Convert.ToString(p.DatumPolaska) + "-" + Convert.ToString(p.DatumPovratka));
                    }
                }
            }

            foreach (Putovanje p in Globalna.nasaAgencija.Putovanja)
            {
                if (p.IdAgencije == Globalna.prijavljenaAgencijaId)
                {
                    if ( comboPutovanja.SelectedItem != null && comboPutovanja.SelectedItem.Equals(p.InfoDestinacije.Naziv + " " + Convert.ToString(p.DatumPolaska) + "-" + Convert.ToString(p.DatumPovratka)))
                    {
                        dDatumPolaska.SetDisplayDate(p.DatumPolaska);
                        dDatumPovratka.SetDisplayDate(p.DatumPovratka);
                        txtBrojPutnika.Text = Convert.ToString(p.TrenutniBrojPutnika);
                        txtTipPrevoza.Text = Convert.ToString(p.InfoPrevoza.VrstaPrevoza);
                        txtCijenaPutovanja.Text = Convert.ToString(p.Cijena);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PocetnaStranica));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Putovanje p in Globalna.nasaAgencija.Putovanja)
            {
                if (p.IdAgencije == Globalna.prijavljenaAgencijaId)
                {
                    if (comboPutovanja.SelectedItem.Equals(p.InfoDestinacije.Naziv + " " + Convert.ToString(p.DatumPolaska) + "-" + Convert.ToString(p.DatumPovratka)))
                    {
                        dDatumPolaska.SetDisplayDate(p.DatumPolaska);
                        dDatumPovratka.SetDisplayDate(p.DatumPovratka);
                        txtBrojPutnika.Text = Convert.ToString(p.TrenutniBrojPutnika);
                        txtTipPrevoza.Text = Convert.ToString(p.InfoPrevoza.VrstaPrevoza);
                        txtCijenaPutovanja.Text = Convert.ToString(p.Cijena);
                    }
                }
            }
        }
    }
}
