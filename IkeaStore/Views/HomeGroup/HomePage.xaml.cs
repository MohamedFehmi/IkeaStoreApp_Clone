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
            
            // Setting the binding context
            homeViewModel = Resources["vm"] as HomeViewModel;
            this.BindingContext = homeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void SearchBar_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            // Make the search list view covers the whole content of the page
            homeViewModel.IsSearchListActive = true;
            
            // Hide the scan barcode button
            homeViewModel.IsScanBarcodeBtnVisible = false;
        }

        void SearchBar_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            // Hide the search list view
            homeViewModel.IsSearchListActive = false;

            // Display the scan barcode button again
            homeViewModel.IsScanBarcodeBtnVisible = true;
        }
    }
}
