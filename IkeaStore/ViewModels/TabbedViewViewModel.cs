using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using IkeaStore.Models;
using IkeaStore.Services;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class TabbedViewViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToOfferDetailsPageCommand { private set; get; }
        ArticleService articleService;

        //public List<Article> ArticlesList;

        public TabbedViewViewModel()
        {
            NavigateToOfferDetailsPageCommand = new Command(ToOfferDetails);

            articleService = new ArticleService();

            Device.BeginInvokeOnMainThread(async () => await GetAllArticles());
        }

        async public Task GetAllArticles()
        {
            Articles = await articleService.GetNewArticles();
        }

        #region Bindable Properties

        private List<Article> articles = new List<Article>();
        public List<Article> Articles
        {
            get
            {
                return articles;
            }
            set
            {
                articles = value;
                OnPropertyChanged(nameof(Articles));
            }
        }

        #endregion

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
