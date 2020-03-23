using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using IkeaStore.IServices;
using IkeaStore.Services;
using Xamarin.Forms;
using ZXing.Client.Result;

namespace IkeaStore.ViewModels
{
    public class BarcodeScannerViewModel : INotifyPropertyChanged
    {
        private IServiceDialogs serviceDialogs;

        public ICommand ExitBarcodeScannerCommand { get; private set; }
        public ICommand OnBarcodeScannedCommand { get; private set; }
        public ICommand EnterBarcodeManuallyCommand { get; private set; }

        // Scanner attributes
        private ZXing.Result result;
        private bool isAnalyzing = true;
        private bool isScanning = true;

        // Custom Dialog
        private bool isCustomDialogOn;

        // Layout attributes
        private Color barcodeOverlayContainerColor = Color.White;
        private Color resultDigitsBackground = Color.White;
        private Color qrcodeOverlayContainerColor = Color.White;

        private string barcodeIndicatorImageSource = "barcodescannerwhite";
        private string qrcodeIndicatorImageSource = "qrcodewhite";
        private string resultDigits= "000.000.000.000";

        public BarcodeScannerViewModel(IServiceDialogs _serviceDialogs)
        {
            ServiceDialogs = _serviceDialogs;

            ExitBarcodeScannerCommand = new Command(ExitScanner);
            OnBarcodeScannedCommand = new Command(OnBarcodeScanned);
            EnterBarcodeManuallyCommand = new Command(async() => await PromptForBarcodeTyping());
        }

        public void ExitScanner()
        {
            Shell.Current.Navigation.PopModalAsync();
        }


        #region : Scanner

        /// <summary>
        /// Defines the next steps to perform once the scanner finished the scan
        /// with the result as a QR_CODE or BARCODE.
        /// </summary>
        void OnBarcodeScanned()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // Stop scanner from analysing
                    IsAnalyzing = false;

                    // Verify which format is scanned
                    if (Result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
                    {
                        QRcodeOverlayContainerColor = Color.Green;
                        QRcodeIndicatorImageSource = "qrcodegreen";

                        await DealWithScanResult(Result.Text);

                        QRcodeOverlayContainerColor = Color.White;
                        QRcodeIndicatorImageSource = "qrcodewhite";
                    }
                    else
                    {
                        // Do something with the result
                        BarcodeOverlayContainerColor = ResultDigitsBackground = Color.Green;
                        BarcodeIndicatorImageSource = "barcodescannergreen";
                        ResultDigits = SplitDigitsByPeriod(Result.Text);

                        await DealWithScanResult(Result.Text);

                        BarcodeOverlayContainerColor = ResultDigitsBackground = Color.White;
                        BarcodeIndicatorImageSource = "barcodescannerwhite";
                        ResultDigits = "000.000.000.000";
                    }

                    // Restart the scanner
                    IsAnalyzing = true;
                });
            }
            catch (Exception e)
            {
                Shell.Current.DisplayAlert("Error", "Scan can not be performed for now.", "OK");
            }
        }

        /// <summary>
        /// An asynchronous task that deals with the scanned barcode.
        /// Example: call to an API to check the availability of a product with the scanned code argument.
        /// </summary>
        /// <param name="scannedCode">A string that represents the code scanned : Barcode or QRCode</param>
        async Task DealWithScanResult(string scannedCode)
        {
            // Simulate some async work
            // TODO : Remove
            await Task.Delay(2000);

            // TODO: Send a server request to fetch the product data of the scanned barcode/qrcode
            // TODO: Navigate to product detail page if the fetched result is a valid product
        }

        /// <summary>
        /// A property that represents the result object
        /// of the scan operation performed by the Scanner.
        /// </summary>
        public ZXing.Result Result
        {
            get
            {
                return result;
            }

            set
            {
                if (Result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        /// <summary>
        /// Display a UI prompt to the user to enter a barcode number.
        /// Call to another task to handle the result retrieved from the prompt
        /// </summary>
        public async Task PromptForBarcodeTyping()
        {
            //string result = await ServiceDialogs.BarcodeDialog();

            //if (!string.IsNullOrEmpty(result))
            //{
            //    using (UserDialogs.Instance.Loading("Processing barcode"))
            //    {
            //        await DealWithScanResult(result);
            //    }
            //}

            IsCustomDialogOn = true;
        }

        public bool IsAnalyzing
        {
            get
            {
                return isAnalyzing;
            }

            set
            {
                if (IsAnalyzing != value)
                {
                    isAnalyzing = value;
                    OnPropertyChanged(nameof(IsAnalyzing));
                }
            }
        }

        public bool IsScanning
        {
            get
            {
                return isScanning;
            }

            set
            {
                if (IsScanning != value)
                {
                    isScanning = value;
                    OnPropertyChanged(nameof(IsScanning));
                }
            }
        }

        public Color BarcodeOverlayContainerColor
        {
            get
            {
                return barcodeOverlayContainerColor;
            }
            set
            {
                if (BarcodeOverlayContainerColor != value)
                {
                    barcodeOverlayContainerColor = value;
                    OnPropertyChanged(nameof(BarcodeOverlayContainerColor));
                }
            }
        }

        public string ResultDigits
        {
            get
            {
                return resultDigits;
            }

            set
            {
                if (ResultDigits != value)
                {
                    resultDigits = value;
                    OnPropertyChanged(nameof(ResultDigits));
                }
            }
        }

        public Color QRcodeOverlayContainerColor
        {
            get
            {
                return qrcodeOverlayContainerColor;
            }
            set
            {
                if (QRcodeOverlayContainerColor != value)
                {
                    qrcodeOverlayContainerColor = value;
                    OnPropertyChanged(nameof(QRcodeOverlayContainerColor));
                }
            }
        }

        public Color ResultDigitsBackground
        {
            get
            {
                return resultDigitsBackground;
            }

            set
            {
                if (ResultDigitsBackground != value)
                {
                    resultDigitsBackground = value;
                    OnPropertyChanged(nameof(ResultDigitsBackground));
                }
            }
        }

        public string BarcodeIndicatorImageSource
        {
            get
            {
                return barcodeIndicatorImageSource;
            }
            set
            {
                if (BarcodeIndicatorImageSource != value)
                {
                    barcodeIndicatorImageSource = value;
                    OnPropertyChanged(nameof(BarcodeIndicatorImageSource));
                }
            }
        }

        public string QRcodeIndicatorImageSource
        {
            get
            {
                return qrcodeIndicatorImageSource;
            }
            set
            {
                if (QRcodeIndicatorImageSource != value)
                {
                    qrcodeIndicatorImageSource = value;
                    OnPropertyChanged(nameof(QRcodeIndicatorImageSource));
                }
            }
        }

        /// <summary>
        /// Separate each three digits by period '.'
        /// </summary>
        /// <param name="barcodeText">A string representation of the barcode result</param>
        /// <returns> The passed argument splitted by period between each 3 of its digits</returns>
        private string SplitDigitsByPeriod(string barcodeText)
        {
            try
            {
                StringBuilder barcodeSplitted = new StringBuilder();

                var digitCountSinceStartOrLastPeriod = 0;

                for (var index = 0; index < barcodeText.Length; index++)
                {
                    if (digitCountSinceStartOrLastPeriod == 3)
                    {
                        barcodeSplitted.Append('.');
                        barcodeSplitted.Append(barcodeText[index]);

                        // After each insertion of '.' the digit at current index will be inserted, this makes the count at 1 instead of 0
                        digitCountSinceStartOrLastPeriod = 1;
                    }
                    else
                    {
                        barcodeSplitted.Append(barcodeText[index]);
                        digitCountSinceStartOrLastPeriod++;
                    }
                }

                return barcodeSplitted.ToString();
            }
            catch (Exception e)
            {
                return barcodeText;
            }
        }

        #endregion : Scanner

        public IServiceDialogs ServiceDialogs
        {
            get
            {
                return serviceDialogs;
            }
            set
            {
                if (value != null)
                {
                    serviceDialogs = value;
                }
            }
        }

        public bool IsCustomDialogOn
        {
            get
            {
                return isCustomDialogOn;
            }
            set
            {
                if (IsCustomDialogOn != value)
                {
                    isCustomDialogOn = value;
                    OnPropertyChanged(nameof(IsCustomDialogOn));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
