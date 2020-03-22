using System;
using System.Collections.Generic;
using IkeaStore.IServices;
using IkeaStore.Services;
using IkeaStore.ViewModels;
using Xamarin.Forms;
using ZXing.Mobile;

namespace IkeaStore.Views.HomeGroup
{
    public partial class BarcodeScannerPage : ContentPage
    {
        public BarcodeScannerPage()
        {
            InitializeComponent();

            // Get an instance of the service dialogs
            IServiceDialogs serviceDialogs = App.instanceManager.GetServiceDialogsInstance();

            BindingContext = new BarcodeScannerViewModel(serviceDialogs);

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
