﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelBookApp.Model;
using TravelBookApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KreiranjePutovanja : Page
    {
        static KreiranjePutovanjaViewModel putovanjeVM = new KreiranjePutovanjaViewModel();
        static List<String> naziviDestinacija = new List<string>();
        static List<String> naziviHotela = new List<string>();
        List<String> autobusi = new List<string>();
        List<String> avioKompanije = new List<string>();
        List<String> listaPolaznihLetova = new List<string>();
        List<String> listaPovratnihLetova = new List<string>();
        String odabranaDestinacija;
        String odabraniHotel;
        Boolean istaknuto;
       

        public KreiranjePutovanja()
        {
            this.InitializeComponent();
            gLet.Visibility = Visibility.Collapsed;
            gDestinacija.Visibility = Visibility.Collapsed;
            gHotel.Visibility = Visibility.Collapsed;
            if(naziviDestinacija.Count == 0)
            {
                naziviDestinacija.Add("Nijedna od ponuđenih");
                naziviHotela.Add("Nijedan od ponuđenih");

            }
            popuniKomboBoxove();
        }

        public void popuniKomboBoxove()
        {
            cDestinacije.Items.Add(naziviDestinacija);
            cHoteli.Items.Add(naziviHotela);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            Frame.Navigate(typeof(PocetnaStranica));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rAvion.IsChecked == true)
            {
                cPrevoz.Items.Add(autobusi);
                gLet.Visibility = Visibility.Visible;
            }
            else
            {
                cPrevoz.Items.Add(avioKompanije);
                gLet.Visibility = Visibility.Collapsed;
            }
        }

        private void cDestinacije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cDestinacije.SelectedIndex == 0) gDestinacija.Visibility = Visibility.Visible;
            else
            {
                gDestinacija.Visibility = Visibility.Collapsed;
                naziviHotela = putovanjeVM.dajListuHotelaPoDestinaciji(naziviDestinacija[cDestinacije.SelectedIndex]);
                autobusi = putovanjeVM.dajListuBusevaPoDestinacijiIKapacitetu(naziviDestinacija[cDestinacije.SelectedIndex], Convert.ToInt32(sMax.Value));
                   // avioKompanije
            }
            if(cDestinacije.SelectedIndex > -1)
            odabranaDestinacija = naziviDestinacija[cDestinacije.SelectedIndex];

        }

        private void cHoteli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cHoteli.SelectedIndex == 0) gHotel.Visibility = Visibility.Visible;
            gHotel.Visibility = Visibility.Collapsed;

            if (cHoteli.SelectedIndex > -1)
                odabraniHotel = naziviHotela[cHoteli.SelectedIndex];

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //dodat polje za upis opisa putovanja
            Prevoz prevoz;
            if (rAutobus.IsChecked == true)
                prevoz = Globalna.nasaAgencija.Prevozi[cPrevoz.SelectedIndex];
            else
                prevoz = null;

            putovanjeVM.kreirajPutovanje(Convert.ToDateTime(dPolaska.DateFormat), Convert.ToDateTime(dPovratka.DateFormat), Convert.ToInt32(sMin.Value), Convert.ToInt32(sMax.Value), "opis putovanja", istaknuto, Globalna.prijavljenaAgencijaId, Globalna.nasaAgencija.Destinacije[cDestinacije.SelectedIndex], Globalna.nasaAgencija.Hoteli[cHoteli.SelectedIndex], prevoz);

        }

        

        private void bDodajHotel_Click(object sender, RoutedEventArgs e)
        {
            putovanjeVM.dodajNoviHotel(tHotel.Text, null, Convert.ToInt32(sMax.Value), Convert.ToInt32(sMin.Value), Globalna.nasaAgencija.Destinacije[cDestinacije.SelectedIndex], Convert.ToDouble(tCijena.Text));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            istaknuto = true;
        }

        private void rAutobus_Checked(object sender, RoutedEventArgs e)
        {
            cPrevoz.Items.Add(avioKompanije);
            gLet.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            istaknuto = false;
        }

        private void bDodajDestinaciju_Click_1(object sender, RoutedEventArgs e)
        {
            putovanjeVM.dodajNovuDestinaciju(tDestinacija.Text, "-", Kontinenti.Afrika, null); //kako sliku spasit?

        }
    }
}
