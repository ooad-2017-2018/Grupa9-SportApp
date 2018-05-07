using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Security.Cryptography;


namespace Playoff {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(System.Object sender, RoutedEventArgs e) {

        }

        private void SignUp_Click(System.Object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Registration), e);
        }

        private void Login_Click(System.Object sender, RoutedEventArgs e) {
            string k = Classes.Baza.DajPassword(tbUsernameLogin.Text);
            if (k.Length == 0) Registration.Poruka("Taj korisnik ne postoji");
            else {
                MD5 md5Hash = MD5.Create();
                string pass = Classes.Korisnik.KodirajMD5(md5Hash, pbPasswordLogin.Password);
                if (k != pass) Registration.Poruka("Pogresan password");
                else {
                    Registration.Poruka("Dobro dosli nazad " + tbUsernameLogin.Text);
                    //dalje nek se prebaci na slj. formu nakon uspjesnog logina
                }
            }
        }
    }
}