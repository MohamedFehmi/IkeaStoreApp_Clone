using System;
using System.ComponentModel;
using System.Windows.Input;
using IkeaStore.Views.HomeGroup;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand OpenBarcodeScanner { get; private set; }

        public ICommand OpenFacebookPageCommand { get; private set; }
        public ICommand OpenYoutubePageCommand { get; private set; }
        public ICommand OpenTwitterPageCommand { get; private set; }

        private Uri app_uri;
        private Uri browser_uri;

        private Uri facebook_app_uri;
        private Uri youtube_app_uri;
        private Uri twitter_app_uri;

        private Uri facebook_browser_uri;
        private Uri youtube_browser_uri;
        private Uri twitter_browser_uri;

        public HomeViewModel()
        {
            OpenBarcodeScanner = new Command(OpenScannerPage);

            OpenFacebookPageCommand = new Command(OpenApp);
            OpenYoutubePageCommand = new Command(OpenApp);
            OpenTwitterPageCommand = new Command(OpenApp);

            facebook_app_uri = new Uri("fb://IKEAdeutschland");
            youtube_app_uri = new Uri("youtube://user/IKEAdeutschland");
            twitter_app_uri = new Uri("twitter://IKEAdeutschland");

            facebook_browser_uri = new Uri("https://www.facebook.com/IKEAdeutschland/?brand_redir=DISABLE");
            youtube_browser_uri = new Uri("https://m.youtube.com/IKEAdeutschland/");
            twitter_browser_uri = new Uri("https://twitter.com/IKEA_Presse");
        }

        #region: Header view
            // Search list logic
            private bool isSearchListActive;

            public bool IsSearchListActive
            {
                get
                {
                    return isSearchListActive;
                }

                set
                {
                    // Only update value when it is different than the new one
                    if (isSearchListActive != value)
                    {
                        isSearchListActive = value;

                        OnPropertyChanged(nameof(IsSearchListActive));
                    }
                }
            }

            // Scan barcode button logic
            private bool isScanBarcodeBtnVisible = true;

            public bool IsScanBarcodeBtnVisible
            {
                    get
                    {
                        return isScanBarcodeBtnVisible;
                    }

                    set
                    {
                        // Only update value when it is different than the new one
                        if (isScanBarcodeBtnVisible != value)
                        {
                            isScanBarcodeBtnVisible = value;

                            OnPropertyChanged(nameof(IsScanBarcodeBtnVisible));
                        }
                    }
            }

        void OpenScannerPage()
        {
            AppShell.Current.Navigation.PushModalAsync(new BarcodeScannerPage(), true);
        }

        #endregion

        #region: Footer view
        //Open the specified app if supported otherwise open the browser.

        public async void OpenApp(object param)
        {
            bool isAppInstalledOnDevice = false;

            try
            {
                // Select the corresponding uri to be opened in the App
                var theSelectedAppUri = param.Equals("facebook") ? facebook_app_uri : param.Equals("youtube") ? youtube_app_uri : twitter_app_uri;

                app_uri = theSelectedAppUri;

                // Select the corresponding uri to be opened in Browser
                var theSelectedBrowserUri = param.Equals("facebook") ? facebook_browser_uri : param.Equals("youtube") ? youtube_browser_uri : twitter_browser_uri;

                browser_uri = theSelectedBrowserUri;

                // Verify that the app is supported
                isAppInstalledOnDevice = await Launcher.CanOpenAsync(app_uri);

                // App is supported and opening
                if (isAppInstalledOnDevice)
                {
                    await Launcher.OpenAsync(app_uri);
                }
                // App failed to open, opening in browser instead
                else
                {
                    await Launcher.OpenAsync(browser_uri);
                }
            }
            catch (Exception e)
            {
                var targetService = isAppInstalledOnDevice ? $"{param} app" : $"{param} page in the browser";
                await Shell.Current.DisplayAlert("Error",$"Error while opening the {targetService}.","OK");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
