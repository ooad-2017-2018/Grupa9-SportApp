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
    /// A form used for accepting or creating new matches with other teams.
    /// </summary>
    public sealed partial class Matches : Page {
        public Matches() {
            InitializeComponent();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e) {

        }

        private void Odbij_Click(object sender, RoutedEventArgs e) {

        }

        private void OsvjeziZahtjeve_Click(object sender, RoutedEventArgs e) {

        }

        private void Zakazi_Click(object sender, RoutedEventArgs e) {

        }

        private void OsvjeziPotencijalne_Click(object sender, RoutedEventArgs e) {

        }

        private void Nazad_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }
    }
}
