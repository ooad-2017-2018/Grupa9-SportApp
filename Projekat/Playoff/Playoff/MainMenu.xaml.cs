using System;
using System.Threading.Tasks;
using Windows.Globalization;
using Windows.Media.SpeechRecognition;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Playoff.Classes;

namespace Playoff {
    /// <summary>
    /// The main menu of the application, allows navigation to all aspects of the application.
    /// The user may also navigate to any of the options by using the in-built voice recognition.
    /// Simply say the page you wish to navigate to in order to do so.
    /// </summary>
    public sealed partial class MainMenu : Page {

        SpeechRecognizer _speechRecognizer;
        private CoreDispatcher _dispatcher;

        public MainMenu() {
            InitializeComponent();
            Page_Loaded(new object(), new RoutedEventArgs());
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e) {
            _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            var permissionGained = await AudioCapturePermissions.RequestMicrophonePermission();
            if(!permissionGained) return;

            await InitializeRecognizer(SpeechRecognizer.SystemSpeechLanguage);
            // Za debugging: Prikaz poruke o detektovanom jeziku
            // Poruka("Jezik: " + SpeechRecognizer.SystemSpeechLanguage.DisplayName, "Jezik");
            await _speechRecognizer.ContinuousRecognitionSession.StartAsync();
        }

        private async Task InitializeRecognizer(Language recognizerLanguage) {
            if(_speechRecognizer != null) {
                _speechRecognizer.ContinuousRecognitionSession.Completed -= ContinuousRecognitionSession_Completed;
                _speechRecognizer.ContinuousRecognitionSession.ResultGenerated -= ContinuousRecognitionSession_ResultGenerated;
                _speechRecognizer.Dispose();
                _speechRecognizer = null;
            }

            _speechRecognizer = new SpeechRecognizer(recognizerLanguage);

            var expectedResponses = GetMenuOptions();
            var listConstraint = new SpeechRecognitionListConstraint(expectedResponses, "Opcije");
            _speechRecognizer.Constraints.Add(listConstraint);
            await _speechRecognizer.CompileConstraintsAsync();

            _speechRecognizer.ContinuousRecognitionSession.Completed += ContinuousRecognitionSession_Completed;
            _speechRecognizer.ContinuousRecognitionSession.ResultGenerated += ContinuousRecognitionSession_ResultGenerated;
        }

        private async void ContinuousRecognitionSession_Completed(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionCompletedEventArgs args) {
            if(_speechRecognizer.State == SpeechRecognizerState.Idle) {
                await _speechRecognizer.ContinuousRecognitionSession.StartAsync();
            }
        }

        private async void ContinuousRecognitionSession_ResultGenerated(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionResultGeneratedEventArgs args) {
            if(args.Result.Confidence == SpeechRecognitionConfidence.Medium || args.Result.Confidence == SpeechRecognitionConfidence.High) {
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => {
                    await SwitchMenu(args.Result.Text);
                });
            }
        }

        private Task SwitchMenu(string phrase) {
            var cleanedPhrase = phrase.ToLower().Replace(".", string.Empty);
            string[] opcije = GetMenuOptions();

            var e = new RoutedEventArgs();

            if(cleanedPhrase == "matches") MainMenuToMatches(btnMecevi, e);
            else if(cleanedPhrase == "teams") MainMenuToTeams(btnMojiTimovi, e);
            else if(cleanedPhrase == "search") MainMenuToSearch(btnPretraga, e);
            else if(cleanedPhrase == "results") MainMenuToResults(btnRezultati, e);
            else if(cleanedPhrase == "notifications") MainMenuToNotifications(btnNotifikacije, e);

            return Task.CompletedTask;
        }

        private static string[] GetMenuOptions() {
            return new string[]{
                "matches",
                "teams",
                "search",
                "notifications",
                "results"
            };
        }

        async public static void Poruka(string por, string naslov = "") {
            var msg = new Windows.UI.Popups.MessageDialog(por, naslov);
            await msg.ShowAsync();
        }

        public void MainMenuToTeams(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Teams), e);
        }

        public void MainMenuToMatches(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Matches), e);
        }

        public void MainMenuToResults(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Results), e);
        }

        public void MainMenuToSearch(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Search), e);
        }

        public void MainMenuToNotifications(object sender, RoutedEventArgs e) {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Notifications), e);
        }
    }
}