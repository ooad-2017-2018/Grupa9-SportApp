using Playoff.Classes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff {
    /// <summary>
    /// A form used for managing teams and messagging existing or potential members.
    /// </summary>
    public sealed partial class ManageTeam : Page {
        public Tim OdabraniTim;

        public ManageTeam() {
            InitializeComponent();

            // Ubaciti naziv tima u odgovarajuci textbox i zakljucati ga
            // Populirati sve liste i combobox
        }

        public void PorukaTrenutni_Click(object sender, RoutedEventArgs e) {
            // Staviti popup sa string unosom za slanje poruke
            //Poruka msg = new Poruka(, "");
        }

        public void Izbaci_Click(object sender, RoutedEventArgs e) {
            // Confirmation, pa izbacivanje
        }

        public void OsvjeziTrenutne_Click(object sender, RoutedEventArgs e) {
            // Osvjezi listu
        }

        public void PorukaPotencijalni_Click(object sender, RoutedEventArgs e) {
            // Staviti popup sa string unosom za slanje poruke
        }

        public void Dodaj_Click(object sender, RoutedEventArgs e) {
            // Confirmation, pa ubacivanje
        }

        public void OsvjeziPotencijalne_Click(object sender, RoutedEventArgs e) {
            // Osvjezi listu
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
    }
}