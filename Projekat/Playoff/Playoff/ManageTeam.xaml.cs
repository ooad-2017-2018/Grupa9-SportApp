using Playoff.Classes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using System.Threading;
using WebApplication1.Models;
using System.Collections.Generic;

namespace Playoff {
    /// <summary>
    /// A form used for managing teams and messagging existing or potential members.
    /// </summary>
    public sealed partial class ManageTeam : Page {

        public  ManageTeam() {
            InitializeComponent();
            // Postavljanje textboxa sa nazivom tima koji se menadžuje
            tbTim.Text = Baza.OdabraniTim.Ime;
            tbTim.IsReadOnly = true;
            OsvjeziTrenutne();
            Osvjezi();
        }

        public void PorukaTrenutni_Click(object sender, RoutedEventArgs e) {
            // Staviti popup sa string unosom za slanje poruke
            //Poruka msg = new Poruka(, "");
        }

        public async void Izbaci_Click(object sender, RoutedEventArgs e) {
            var kor = await Baza.DajKorisnike();
            int ID = 1;
            foreach (var x in kor) if (lbTrenutniClanovi.SelectedItem.ToString() == x.Username) ID = x.ID;
            Baza.IzbacIzTima(Baza.OdabraniTim.ID, ID);   
            lbPotencijalniClanovi.Items.Add(lbTrenutniClanovi.SelectedItem);
            cbKapiten.Items.Remove(lbTrenutniClanovi.SelectedItem);
            lbTrenutniClanovi.Items.Remove(lbTrenutniClanovi.SelectedItem);

        }

        public async void OsvjeziTrenutni_Click(object sender, RoutedEventArgs e) {
            OsvjeziTrenutne();
        }

        public void PorukaPotencijalni_Click(object sender, RoutedEventArgs e) {
            // Staviti popup sa string unosom za slanje poruke
        }

        public async void Dodaj_Click(object sender, RoutedEventArgs e) {
            var kor = await Baza.DajKorisnike();
            int ID = 1;
            foreach (var x in kor) if (lbPotencijalniClanovi.SelectedItem.ToString() == x.Username) ID = x.ID;
            Baza.DodajUTim(Baza.OdabraniTim.ID, ID);
            lbTrenutniClanovi.Items.Add(lbPotencijalniClanovi.SelectedItem);
            cbKapiten.Items.Add(lbPotencijalniClanovi.SelectedItem);
            lbPotencijalniClanovi.Items.Remove(lbPotencijalniClanovi.SelectedItem);

        }

        public async void OsvjeziPotencijalni_Click(object sender, RoutedEventArgs e) {
            Osvjezi();
        }

        public void Potvrdi_Click(object sender, RoutedEventArgs e) {
            // Update tabelu

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }

        public void Prekid_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }
        async void Osvjezi() {
            var Clanovi = await Baza.DajKorisnike();
            var TrenutniClanovi = await Baza.DajClanoveTima(Baza.OdabraniTim.ID);
            List<OOADKorisnici> potencijalni = new List<OOADKorisnici>();

            foreach (var x in Clanovi) {
                bool brisi = true;
                foreach (var y in TrenutniClanovi)
                    if (x.ID == y.ID) brisi = false;
                if (brisi) potencijalni.Add(x);
            }

            foreach (var tim in potencijalni) lbPotencijalniClanovi.Items.Add(tim.Ime);
        }
        async void OsvjeziTrenutne() {
            var TrenutniClanovi = await Baza.DajClanoveTima(Baza.OdabraniTim.ID);
            foreach (var tim in TrenutniClanovi) { lbTrenutniClanovi.Items.Add(tim.Ime); cbKapiten.Items.Add(tim.Ime); }
        }
    }
}