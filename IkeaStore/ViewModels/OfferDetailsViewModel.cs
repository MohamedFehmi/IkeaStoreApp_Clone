using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class OfferDetailsViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateBackToHomePage { private set; get; }
        public ICommand OpenAllOffersInBrowser { private set; get; }
        
        public OfferDetailsViewModel()
        {
            NavigateBackToHomePage = new Command(NavigateBack);
            OpenAllOffersInBrowser = new Command(OpenAllOffers);

            // Retrieve the offer object
        }

        public void NavigateBack()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public async void OpenAllOffers()
        {
            await OpenBrowser(new Uri("https://www.ikea.com/de/de/angebote/?icid=a1:store_app%7Ca2:de%7Ca6:local_store_campaign%7Ccc:216"));
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
