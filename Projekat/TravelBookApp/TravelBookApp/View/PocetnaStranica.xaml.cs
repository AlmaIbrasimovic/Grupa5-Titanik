using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PocetnaStranica : Page
    {
        public PocetnaStranica()
        {
            this.InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Prijava));
        }

        private void bKreirajPutovanje_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KreiranjePutovanja));
        }

        private void bPregledHistorije_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PrethodnaPutovanja));
        }

        private void bPregledPutovanja_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PrethodnaPutovanja));
        }
    }
}
