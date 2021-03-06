﻿using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Security.Cryptography;
using Windows.UI.ViewManagement;

namespace Playoff {
    /// <summary>
    /// A page used for registering a new account.
    /// </summary>
    public sealed partial class Registration : Page {
        public Registration() {
            this.InitializeComponent();
            dpDatumRodjenjaRegister.MaxDate = DateTimeOffset.Now;
        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            // Validacija da su polja popunjena
            if (tbUsernameRegister.Text.Length == 0 || pbConfirmPasswordRegister.Password.Length == 0 || tbImeRegister.Text.Length == 0 || tbPrezimeRegister.Text.Length == 0 || dpDatumRodjenjaRegister.Date == null || tbDrzavaRegister.Text.Length == 0 || tbGradRegistration.Text.Length == 0) Poruka("Sva polja moraju biti popunjena", "Error");
            // Validacija potvrđenog passworda
            else if (pbConfirmPasswordRegister.Password != pbPasswordRegister.Password) Poruka("Niste potvrdili odabrani password", "Error");
            else if (pbPasswordRegister.Password.Length < 6) Poruka("Password mora sadrzavati minimalno 6 karaktera", "Error");
            else {
                try {
                    MD5 md5Hash = MD5.Create();
                    string password = Classes.Korisnik.KodirajMD5(md5Hash, pbPasswordRegister.Password);
                    // Registruje korisnika na bazu podataka i prikazuje poruku da je uspješno registrovan
                    string k = Classes.Baza.RegistrujKorisnika(tbUsernameRegister.Text, password, tbImeRegister.Text, tbPrezimeRegister.Text, new DateTime(dpDatumRodjenjaRegister.Date.Value.Year, dpDatumRodjenjaRegister.Date.Value.Month, dpDatumRodjenjaRegister.Date.Value.Day), tbDrzavaRegister.Text, tbGradRegistration.Text, 0);
                    if (k != "N") {
                        Poruka("Uspjesno ste kreirali novi account");
                        rootFrame.Navigate(typeof(MainPage), e);
                    }
                } catch (System.Data.SqlClient.SqlException ex) {
                    //Ne mogu postojati dva korisnika sa istim username-om
                    if (ex.Message.Contains("UNIQUE")) Poruka("Korisnik sa tim username-om vec postoji", "Error");
                    Poruka(ex.Message);
                }
            }
        }

        private void CancelRegister_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), e);

            // Postavi minimalne inicijalne dimenzija na pokretanju
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(360, 640));
        }

        // Olakšan prikaz MessageDialog prozora
        async public static void Poruka(string por, string naslov = "") {
            var msg = new MessageDialog(por, naslov);
            await msg.ShowAsync();
        }
    }
}