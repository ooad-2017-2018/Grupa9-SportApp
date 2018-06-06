using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff.Classes {
    /// <summary>
    /// Form used for creating a new team.
    /// </summary>
    public sealed partial class CreateTeam : Page {
        public CreateTeam() {
            InitializeComponent();
        }

        public void KreirajTim_Click(object sender, RoutedEventArgs e) {
            Baza.KreirajTim(tbNazivTima.Text, cbSport.ToString());

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }

        public void Prekid_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }
    }
}
