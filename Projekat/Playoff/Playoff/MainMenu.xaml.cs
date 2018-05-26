using System;
using System.Threading.Tasks;
using Windows.Globalization;
using Windows.Media.SpeechRecognition;
using Windows.System.UserProfile;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Playoff.Classes;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playoff {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page {

        SpeechRecognizer _speechRecognizer;
        private CoreDispatcher _dispatcher;

        public MainMenu() {
            InitializeComponent();
            Page_Loaded(new object(), new RoutedEventArgs());
            /*
            var korisnickiJezik = GlobalizationPreferences.Languages[0];
            var jezik = new Language(korisnickiJezik);
            var voiceRec = new SpeechRecognizer(jezik);
            */
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e) {
            _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            var permissionGained = await AudioCapturePermissions.RequestMicrophonePermission();
            if(!permissionGained) return;

            await InitializeRecognizer(SpeechRecognizer.SystemSpeechLanguage);
            Poruka("Jezik: " + SpeechRecognizer.SystemSpeechLanguage.DisplayName, "Jezik");
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

            // DODATI PRELAZE ZA FORME, ISPRAVITI VOICE RECOGNITION
            
            foreach(string opcija in opcije) {
                if(cleanedPhrase == opcija) Poruka("Opcija: ", cleanedPhrase);
            }

            /*
            if(opcije.Contains(cleanedPhrase)) {
                Poruka("Opcija: " + cleanedPhrase);

                if(cleanedPhrase == "profile") {
                    
                } else if(cleanedPhrase == "teams") {

                } else if(cleanedPhrase == "tournaments") {

                } else if(cleanedPhrase == "search") {

                } else if(cleanedPhrase == "notifications") {

                }
            }
            */

            return Task.CompletedTask;
        }

        /*
        private static List<string> GetMenuOptions() {
            List<string> opcije = new List<string>();

            opcije.Add("profile");
            opcije.Add("teams");
            opcije.Add("tournaments");
            opcije.Add("search");
            opcije.Add("notifications");

            return opcije;
        }
        */

        private static string[] GetMenuOptions() {
            return new string[]{
                "profile",
                "teams",
                "tournaments",
                "search",
                "notifications"
            };
        }

        async public static void Poruka(string por, string naslov = "") {
            var msg = new Windows.UI.Popups.MessageDialog(por, naslov);
            await msg.ShowAsync();
        }
    }
}