using System;
using System.Collections.Generic;
using IkeaStore.ViewModels;
using Xamarin.Forms;

namespace IkeaStore.Views.HomeGroup
{
    public partial class BarcodeScannerPage : ContentPage
    {
        private ScannerViewModel scannerViewModel;

        public BarcodeScannerPage()
        {
            InitializeComponent();

            scannerViewModel = Resources["vm"] as ScannerViewModel;
            this.BindingContext = scannerViewModel;
        }
    }
}
