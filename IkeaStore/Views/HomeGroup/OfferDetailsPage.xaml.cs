using IkeaStore.ViewModels;
using Xamarin.Forms;

namespace IkeaStore.Views.HomeGroup
{
    public partial class OfferDetailsPage : ContentPage
    {
        OfferDetailsViewModel offerDetailsViewModel;

        public OfferDetailsPage()
        {
            InitializeComponent();

            offerDetailsViewModel = Resources["vm"] as OfferDetailsViewModel;
            this.BindingContext = offerDetailsViewModel;
        }
    }
}