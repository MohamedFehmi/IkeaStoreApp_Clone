using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand OpenFacebookPage { get; private set; }
        public ICommand OpenYoutubePage { get; private set; }
        public ICommand OpenTwitterPage { get; private set; }

        private Uri uri;

        public HomeViewModel()
        {
            OpenFacebookPage = new Command(OpenFacebook);
            OpenYoutubePage = new Command(OpenYoutube);
            OpenTwitterPage = new Command(OpenTwitter);
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

        #endregion

        #region: Footer view
        //Open the specified app if supported otherwise open the browser.

        public async void OpenFacebook()
        {
            try
            {
                uri = new Uri("fb://IKEAdeutschland");
                bool isAppInstalledOnDevice = await Launcher.CanOpenAsync(uri);

                if (isAppInstalledOnDevice)
                {
                    await Launcher.OpenAsync(uri);
                }
                else
                {
                    uri = new Uri("https://www.facebook.com/IKEAdeutschland/?brand_redir=DISABLE");
                    await Launcher.OpenAsync(uri);
                }
            }
            catch (Exception e)
            {
            }
        }

        public async void OpenYoutube()
        {
            try
            {
                uri = new Uri("vnd.youtube://IKEAdeutschland");
                bool isAppInstalledOnDevice = await Launcher.CanOpenAsync(uri);

                if (isAppInstalledOnDevice)
                {
                    await Launcher.OpenAsync(uri);
                }
                else
                {
                    uri = new Uri("https://m.youtube.com/IKEAdeutschland/");
                    await Launcher.OpenAsync(uri);
                }
            }
            catch (Exception e)
            {
            }
        }

        public async void OpenTwitter()
        {
            try
            {
                uri = new Uri("twitter://IKEAdeutschland");
                bool isAppInstalledOnDevice = await Launcher.CanOpenAsync(uri);

                if (isAppInstalledOnDevice)
                {
                    await Launcher.OpenAsync(uri);
                }
                else
                {
                    uri = new Uri("https://twitter.com/IKEA_Presse");
                    await Launcher.OpenAsync(uri);
                }
            }
            catch (Exception e)
            {
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
