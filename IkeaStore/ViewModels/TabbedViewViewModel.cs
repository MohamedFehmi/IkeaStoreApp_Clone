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

        //public List<Article> ArticlesList;

        public TabbedViewViewModel()
        {
            NavigateToOfferDetailsPageCommand = new Command(ToOfferDetails);

            Device.BeginInvokeOnMainThread(async () => await GetAllArticles());

            //ArticlesList = new List<Article>()
            //{
            //    new Article () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
            //    new Article () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
            //    new Article () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu" },
            //    new Article () { Name = "MALM", Details = "6-drawer dresser", Price = 179.00, Currency = "$", Category = "Neu", IsLastItemInArticles = true }
            //};
        }

        async public Task<List<Article>> GetAllArticles()
        {
            return null;
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
