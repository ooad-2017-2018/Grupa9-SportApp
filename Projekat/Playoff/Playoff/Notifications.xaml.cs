using Playoff.Classes;
using System.Collections.Generic;
using WebApplication1.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff {
    /// <summary>
    /// A form containing notifications received by the user, as well as the ability to send messages.
    /// </summary>
    public sealed partial class Notifications : Page {
        List<OOADPoruka> poruke;

        public Notifications() {
            InitializeComponent();
            UcitajPoruke();
        }

        public async void UcitajPoruke() {
            poruke = await Baza.DajPoruke();
            foreach(OOADPoruka poruka in poruke) {
                string sadrzajPrikaz = "";
                int i = 20;
                foreach(char karakter in poruka.Sadrzaj) {
                    sadrzajPrikaz += karakter;
                    if(--i == 0) break;
                }
                lbNotifikacije.Items.Add(poruka.Posiljaoc + " - " + sadrzajPrikaz);
            }
        }
        
        public OOADPoruka VratiPoruku(string naziv) {
            string posiljaoc = "";
            string sadrzaj = "";
            bool traziPosiljaoca = true;
            int formatKarakteri = 3;

            foreach(char karakter in naziv) {
                if(karakter == ' ') traziPosiljaoca = false;
                if(traziPosiljaoca) posiljaoc += karakter;
                else {
                    if(formatKarakteri-- != 0) continue;
                    sadrzaj += karakter;
                }
            }

            int posiljaocID = Baza.DajMojID(posiljaoc);

            foreach(OOADPoruka poruka in poruke) {
                // Velika optimizacija jer sprijecava Contains metodu koja je ULTRA neefikasna
                if(poruka.Posiljaoc == posiljaocID && poruka.Sadrzaj.Contains(sadrzaj)) return poruka; 
            }

            return new OOADPoruka();
        }

        public void Obrisi_Click(object sender, RoutedEventArgs e) {
            OOADPoruka odabrano = VratiPoruku(lbNotifikacije.SelectedItem.ToString());
            lbNotifikacije.Items.Remove(odabrano);
            poruke.Remove(odabrano);
            Baza.ObrisiPoruku(odabrano.ID);
        }

        public void NovaPoruka_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(NovaPoruka), e);
        }

        public void Nazad_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }

        private void lbNotifikacije_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            OOADPoruka poruka = VratiPoruku(lbNotifikacije.SelectedItem.ToString());
            tbTekstPoruke.Text = poruka.Sadrzaj;
        }
    }
}
