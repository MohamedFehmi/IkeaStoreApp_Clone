using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class TabbedViewViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToOfferDetailsPage { private set; get; }

        public TabbedViewViewModel()
        {
            NavigateToOfferDetailsPage = new Command(ToOfferDetails);
        }

        private void ToOfferDetails()
        {
            Shell.Current.GoToAsync("offerdetails");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
