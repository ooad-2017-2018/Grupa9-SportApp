using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Security.Cryptography;
using Windows.UI.ViewManagement;

namespace Playoff {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page {
        public Registration() {
            this.InitializeComponent();
            dpDatumRodjenjaRegister.MaxDate = DateTimeOffset.Now;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e) {

        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            //testiraj da li su prazna polja
            if (tbUsernameRegister.Text.Length == 0 || pbConfirmPasswordRegister.Password.Length == 0 || tbImeRegister.Text.Length == 0 || tbPrezimeRegister.Text.Length == 0 || dpDatumRodjenjaRegister.Date == null || tbDrzavaRegister.Text.Length == 0 || tbGradRegistration.Text.Length == 0) Poruka("Sva polja moraju biti popunjena", "Error");
            //testiraj da li je korisnik potvrdio password
            else if (pbConfirmPasswordRegister.Password != pbPasswordRegister.Password) Poruka("Niste potvrdili odabrani password", "Error");
            else if (pbPasswordRegister.Password.Length < 6) Poruka("Password mora sadrzavati minimalno 6 karaktera", "Error");
            else {
                try {
                    MD5 md5Hash = MD5.Create();
                    string password = Classes.Korisnik.KodirajMD5(md5Hash, pbPasswordRegister.Password);
                    //registruje korisnika na bazu podataka i prikazuje poruku da je uspjesno registrovan
                    string k = Classes.Baza.RegistrujKorisnika(tbUsernameRegister.Text, password, tbImeRegister.Text, tbPrezimeRegister.Text, new DateTime(dpDatumRodjenjaRegister.Date.Value.Year, dpDatumRodjenjaRegister.Date.Value.Month, dpDatumRodjenjaRegister.Date.Value.Day), tbDrzavaRegister.Text, tbGradRegistration.Text, 0);
                    if (k != "N") {
                        Poruka("Uspjesno ste kreirali novi account");
                        rootFrame.Navigate(typeof(MainPage), e);
                    }
                } catch (System.Data.SqlClient.SqlException ex) {
                    //Ne mogu postojati dva korisnika sa istim username-om
                    if (ex.Message.Contains("UNIQUE")) Poruka("Korisnik sa tim username-om vec postoji", "Error");
                }
            }
        }

        private void CancelRegister_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), e);

            // Set minimum dimensions and initial dimensions on launch
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(360, 640));
        }
        //sluzi za prikaz MessageDialog prozora
        async public static void Poruka(string por, string naslov = "") {
            var msg = new MessageDialog(por, naslov);
            await msg.ShowAsync();
        }
    }
}