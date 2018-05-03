using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Playoff {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page {
        public Registration() {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e) {

        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;

            // Logika oko baze podataka, validacija i ispis uspjesne/neuspjesne validacije

            
            // Pokrenuti samo u slučaju da je uspješno registrovan korisnik, vraća na Login screen
            rootFrame.Navigate(typeof(MainPage), e);
        }

        private void CancelRegister_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), e);
        }
    }
}