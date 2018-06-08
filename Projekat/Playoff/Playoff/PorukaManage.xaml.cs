using Playoff.Classes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playoff {
    /// <summary>
    /// A form used for sending messages to other users.
    /// </summary>
    public sealed partial class PorukaManage : Page {
        public PorukaManage() {
            InitializeComponent();
        }

        public void Posalji_Click(object sender, RoutedEventArgs e) {
            try {
                Baza.PosaljiPoruku(tbPrimaoc.Text, tbPoruka.Text);
                Registration.Poruka("Poruka uspješno poslana!", "Uspjeh");
            } catch {
                Registration.Poruka("Taj korisnik ne postoji!", "Greška");
            }
        }

        public void Prekini_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ManageTeam), e);
        }
    }
}