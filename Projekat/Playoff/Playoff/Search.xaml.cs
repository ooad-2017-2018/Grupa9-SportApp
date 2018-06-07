using Playoff.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebApplication1.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Playoff {
    /// <summary>
    /// A form used for looking up other nearby players or teams with similar MMR.
    /// </summary>
    public sealed partial class Search : Page {
        List<OOADTimovi> timovi;
        public static string[] sportovi = { "Nogomet", "Košarka", "Odbojka", "Tenis", "Trčanje" };

        public Search() {
            InitializeComponent();
            RefreshUserTeams();
            // Generiši sadržaj comboboxa za sport
            foreach(var sport in sportovi) cbSport.Items.Add(sport);
            cbSport.SelectedItem = "Nogomet";
            // Generiši sadržaj comboboxa za timove
        }

        public async void RefreshUserTeams() {
            cbTim.Items.Clear();
            // Dohvatiti sve timove prijavljenog korisnika i dodati ih u listu
            // Izlistani su nazivi, a kasnije se pri slanju zahtjeva traži odabrani tim
            timovi = await Baza.DajMojeTimove();
            foreach(var tim in timovi) cbTim.Items.Add(tim.Ime);
        }

        private void Timovi_Click(object sender, RoutedEventArgs e) {
            lbTimovi.Visibility = Visibility.Visible;
            lbIgraci.Visibility = Visibility.Collapsed;
            labTim.Visibility = Visibility.Visible;
            cbTim.Visibility = Visibility.Visible;
        }

        private void Igraci_Click(object sender, RoutedEventArgs e) {
            lbTimovi.Visibility = Visibility.Collapsed;
            lbIgraci.Visibility = Visibility.Visible;
            labTim.Visibility = Visibility.Collapsed;
            cbTim.Visibility = Visibility.Collapsed;
        }

        private void Profil_Click(object sender, RoutedEventArgs e) {

        }

        private void Zahtjev_Click(object sender, RoutedEventArgs e) {

        }

        private void Nazad_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }
    }
}
