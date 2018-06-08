using Playoff.Classes;
using System.Collections.Generic;
using WebApplication1.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff {
    /// <summary>
    /// A page for viewing the user's teams, as well as branching off into team creation or team editing.
    /// </summary>
    public sealed partial class Teams : Page {
        List<OOADTimovi> timovi;

        public Teams() {
            InitializeComponent();
            RefreshTeams();
        }

        public void Refresh_Click(object sender, RoutedEventArgs e) {
            RefreshTeams();
        }

        public async void RefreshTeams() {
            lbTimovi.Items.Clear();
            // Dohvatiti sve timove prijavljenog korisnika i dodati ih u listu
            // Izlistani su nazivi, a kasnije se pri prelasku na menadžment traži odabrani tim
            try {
                timovi = await Baza.DajMojeTimove();
                foreach (var tim in timovi) lbTimovi.Items.Add(tim.Ime);
            } catch { }
        }

        public void ToMainMenu(object sender, RoutedEventArgs e) {
            Baza.OdabraniTim = null;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }

        public void ToManageTeam(object sender, RoutedEventArgs e) {
            if(lbTimovi.SelectedItem == null) return;
            // Postavi trenutno odabrani tim kako bi se on mogao koristiti u formi ManageTeam
            Baza.OdabraniTim = (OOADTimovi)timovi.Find(x => lbTimovi.SelectedItem.ToString() == x.Ime);
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ManageTeam), e);
        }

        public void ToCreateTeam(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CreateTeam), e);
        }

        private void AddFootball(object sender, RoutedEventArgs e) {
            foreach(OOADTimovi tim in timovi) if(Baza.DajSport(tim.Ime) == "Fudbal") lbTimovi.Items.Add(tim);
        }

        private void AddBasketball(object sender, RoutedEventArgs e) {
            foreach(OOADTimovi tim in timovi) if(Baza.DajSport(tim.Ime) == "Košarka") lbTimovi.Items.Add(tim);
        }

        private void AddTennis(object sender, RoutedEventArgs e) {
            foreach(OOADTimovi tim in timovi) if(Baza.DajSport(tim.Ime) == "Tenis") lbTimovi.Items.Add(tim);
        }

        private void AddRunning(object sender, RoutedEventArgs e) {
            foreach(OOADTimovi tim in timovi) if(Baza.DajSport(tim.Ime) == "Trcanje") lbTimovi.Items.Add(tim);
        }

        private void AddVolleyball(object sender, RoutedEventArgs e) {
            foreach(OOADTimovi tim in timovi) if(Baza.DajSport(tim.Ime) == "Odbojka") lbTimovi.Items.Add(tim);
        }

        private void RemoveFootball(object sender, RoutedEventArgs e) {
            List<string> temp = new List<string>();
            foreach(string tim in lbTimovi.Items) if(timovi.Find(x => x.Ime == tim) != null) if(Baza.DajSport(tim) != "Nogomet") temp.Add(tim);
            lbTimovi.Items.Clear();
            foreach(string tim in temp) lbTimovi.Items.Add(tim);
        }

        private void RemoveBasketball(object sender, RoutedEventArgs e) {
            List<string> temp = new List<string>();
            foreach(string tim in lbTimovi.Items) if(timovi.Find(x => x.Ime == tim) != null) if(Baza.DajSport(tim) != "Košarka") temp.Add(tim);
            lbTimovi.Items.Clear();
            foreach(string tim in temp) lbTimovi.Items.Add(tim);
        }

        private void RemoveTennis(object sender, RoutedEventArgs e) {
            List<string> temp = new List<string>();
            foreach(string tim in lbTimovi.Items) if(timovi.Find(x => x.Ime == tim) != null) if(Baza.DajSport(tim) != "Tenis") temp.Add(tim);
            lbTimovi.Items.Clear();
            foreach(string tim in temp) lbTimovi.Items.Add(tim);
        }

        private void RemoveRunning(object sender, RoutedEventArgs e) {
            List<string> temp = new List<string>();
            foreach(string tim in lbTimovi.Items) if(timovi.Find(x => x.Ime == tim) != null) if(Baza.DajSport(tim) != "Trcanje") temp.Add(tim);
            lbTimovi.Items.Clear();
            foreach(string tim in temp) lbTimovi.Items.Add(tim);
        }

        private void RemoveVolleyball(object sender, RoutedEventArgs e) {
            List<string> temp = new List<string>();
            foreach(string tim in lbTimovi.Items) if(timovi.Find(x => x.Ime == tim) != null) if(Baza.DajSport(tim) != "Odbojka") temp.Add(tim);
            lbTimovi.Items.Clear();
            foreach(string tim in temp) lbTimovi.Items.Add(tim);
        }
    }
}