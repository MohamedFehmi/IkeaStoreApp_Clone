using System;
using System.Collections.Generic;
using IkeaStore.ViewModels;
using Xamarin.Forms;

namespace IkeaStore.Views.HomeGroup
{
    public partial class HomePage : ContentPage
    {
        // Variables
        private HomeViewModel homeViewModel;


        public HomePage()
        {
            InitializeComponent();

            // Get the view model bound to the page
            homeViewModel = Resources["vm"] as HomeViewModel;
            this.BindingContext = homeViewModel;
        }

        // Make the search list view covers the whole content of the page
        void SearchBar_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            homeViewModel.IsSearchListActive = true;
        }

        // Hide the search list view
        void SearchBar_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            homeViewModel.IsSearchListActive = false;
        }
    }
}
