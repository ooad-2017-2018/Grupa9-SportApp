using System;
using System.Threading.Tasks;
using Windows.Media.Capture;

namespace Playoff.Classes {
    public class AudioCapturePermissions {
        // U slučaju da uređaj nema audio input, baca System.Exception objekt sa ovom vrijednosti
        private static int NoCaptureDevicesHResult = -1072845856;

        /// <summary>
        /// Na desktopu/tabletu, potrebno je aplikaciji dati dozvolu za audio capture.
        /// Ova metoda testira postavku privatnosti za pristup mikrofona ove aplikacije.
        /// </summary>
        /// <returns>True ako se mikrofonu može pristupiti bez problema</returns>
        public async static Task<bool> RequestMicrophonePermission() {
            try {
                // Zahtjev pristupa mikrofonu
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings();
                settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
                settings.MediaCategory = MediaCategory.Speech;
                MediaCapture capture = new MediaCapture();

                await capture.InitializeAsync(settings);
            } catch(TypeLoadException) {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Glasovne komponente nedostupne.");
                await messageDialog.ShowAsync();
                return false;
            } catch(UnauthorizedAccessException) {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Aplikaciji nije dozvoljen pristup mikrofonu.");
                return false;
            } catch(Exception exception) {
                if(exception.HResult == NoCaptureDevicesHResult) {
                    var messageDialog = new Windows.UI.Popups.MessageDialog("Nije pronađen mikrofon.");
                    await messageDialog.ShowAsync();
                    return false;
                } else throw;
            }
            return true;
        }
    }
}
