using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff.Classes {
    /// <summary>
    /// Form used for creating a new team.
    /// </summary>
    public sealed partial class CreateTeam : Page {
        public static string[] sportovi = { "Nogomet", "Košarka", "Odbojka", "Tenis", "Trčanje" };

        public CreateTeam() {
            InitializeComponent();
            // Generiši sadržaj comboboxa
            foreach(var sport in sportovi) cbSport.Items.Add(sport);
            cbSport.SelectedItem = "Nogomet";
        }

        public void KreirajTim_Click(object sender, RoutedEventArgs e) {
            string sport = cbSport.SelectedItem.ToString();
            if(sport == "Nogomet") sport = "Fudbal";
            else if(sport == "Trčanje") sport = "Trcanje";
            
            Baza.KreirajTim(tbNazivTima.Text, sport);

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);

            Registration.Poruka("Kreirali ste tim " + tbNazivTima.Text, "Uspjeh!");
        }

        public void Prekid_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }
    }
}
