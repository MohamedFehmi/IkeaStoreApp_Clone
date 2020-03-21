using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using IkeaStore.Models;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class TabbedViewViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToOfferDetailsPageCommand { private set; get; }

        public List<Product> ProductsList;

        public TabbedViewViewModel()
        {
            NavigateToOfferDetailsPageCommand = new Command(ToOfferDetails);

            ProductsList = new List<Product>()
            {
                new Product () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
                new Product () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
                new Product () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
                new Product () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu", IsLastItemInProducts = true }
            };
        }

        async public Task<List<Product>> GetAllProducts()
        {
            return ProductsList;
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
