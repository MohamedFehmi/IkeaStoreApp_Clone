using System;
using System.Collections.Generic;
using IkeaStore.ViewModels;
using Xamarin.Forms;
using ZXing.Mobile;

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

            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
                PossibleFormats = new List<ZXing.BarcodeFormat> { ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.QR_CODE}
            };

            _scanView.Options = options;
        }
    }
}
