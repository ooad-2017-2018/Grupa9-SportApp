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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playoff {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Results : Page {
        public Results() {
            this.InitializeComponent();
        }

        private void Prihvati_Click(object sender, RoutedEventArgs e) {

        }

        private void Odbij_Click(object sender, RoutedEventArgs e) {

        }

        private void OsvjeziPredlozene_Click(object sender, RoutedEventArgs e) {

        }

        private void Predlozi_Click(object sender, RoutedEventArgs e) {

        }

        private void OsvjeziOdigrane_Click(object sender, RoutedEventArgs e) {

        }

        private void Nazad_Click(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainMenu), e);
        }
    }
}
