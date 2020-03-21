using System;
using System.Collections.Generic;
using IkeaStore.ViewModels;
using Xamarin.Forms;

namespace IkeaStore.Views.HomeGroup
{
    public partial class BarcodeScannerPage : ContentPage
    {
        private BarcodeScannerViewModel barcodeScannerViewModel;

        public BarcodeScannerPage()
        {
            InitializeComponent();

            barcodeScannerViewModel = Resources["vm"] as BarcodeScannerViewModel;
            this.BindingContext = barcodeScannerViewModel;
        }
    }
}
