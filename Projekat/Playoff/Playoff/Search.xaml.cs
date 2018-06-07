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

        private async void Timovi_Click(object sender, RoutedEventArgs e) {
            lbTimovi.Visibility = Visibility.Collapsed;
            lbIgraci.Visibility = Visibility.Visible;
            labTim.Visibility = Visibility.Collapsed;
            cbTim.Visibility = Visibility.Collapsed;
            var timovi = await Baza.DajTimove();
            var moji = await Baza.DajMojeTimove();
            List<OOADTimovi> list = new List<OOADTimovi>();
            foreach (var x in timovi)
                foreach (var y in moji)
                    if (x.ID == y.ID) list.Add(y);

            foreach (var x in list) timovi.Remove(x);
            var zah = await Baza.DajPoslaneZahtjeve();
            foreach (var x in zah)
                for (int i = 0; i < timovi.Count; i++)
                    if (timovi[i].ID == x.Primaoc) timovi.RemoveAt(i);

            foreach (var x in timovi) lbIgraci.Items.Add(x.Ime);

        }

        private async void Igraci_Click(object sender, RoutedEventArgs e) {
            lbTimovi.Visibility = Visibility.Visible;
            lbIgraci.Visibility = Visibility.Collapsed;
            labTim.Visibility = Visibility.Visible;
            cbTim.Visibility = Visibility.Visible;

            var igr = await Baza.DajKorisnike();
            for (int i = 0; i < igr.Count; i++)
                if (igr[i].ID == Baza.ID1) igr.RemoveAt(i);
            foreach (var x in igr) lbTimovi.Items.Add(x.Ime + " "+x.Prezime);
        }

        private void Profil_Click(object sender, RoutedEventArgs e) {
            
        }

        private void Zahtjev_Click(object sender, RoutedEventArgs e) {
            if (lbIgraci.Visibility.Equals(Visibility.Visible)) {
                Baza.PosaljiZahtjev(lbIgraci.SelectedItem.ToString(), "Zelio bih da se pridruzim vasem timu");
                lbIgraci.Items.Remove(lbIgraci.SelectedItem);
            } else {
                Baza.PosaljiPoruku(lbTimovi.SelectedItem.ToString(), "Zelim da se pridruzis mom timu " + cbTim.SelectedItem + ", Samo nam posalji zahtjev ako zelis");
                lbTimovi.Items.Remove(lbTimovi.SelectedItem);
            }
            Registration.Poruka("Zahtjev uspješno poslan");
        }

        private void Nazad_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }
    }
}
