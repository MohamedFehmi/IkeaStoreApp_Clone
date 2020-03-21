using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class ScannerViewModel : INotifyPropertyChanged
    {
        public ICommand ExitBarcodeScannerCommand { get; private set; }
        public ICommand OnBarcodeScannedCommand { get; private set; }

        private ZXing.Result result;

        private bool isAnalyzing = true;
        private bool isScanning = true;

        private Color barcodeOverlayContainer = Color.White;
        private Color resultDigitsBackground = Color.White;

        private string resultDigits= "000.000.000.000";

        public ScannerViewModel()
        {
            ExitBarcodeScannerCommand = new Command(ExitScanner);
            OnBarcodeScannedCommand = new Command(OnBarcodeScanned);
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
            Device.BeginInvokeOnMainThread(async () =>
            {
                // Stop scanner from analysing
                IsAnalyzing = false;

                // Do something with the result
                BarcodeOverlayContainer = ResultDigitsBackground = Color.Green;
                ResultDigits = SplitDigitsByPeriod(Result.Text);

                await Task.Delay(4000);

                BarcodeOverlayContainer = ResultDigitsBackground = Color.White;
                ResultDigits = "000.000.000.000";

                // Write to the local database the scanned products



                // Restart the scanner
                IsAnalyzing = true;
            });
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

        public Color BarcodeOverlayContainer
        {
            get
            {
                return barcodeOverlayContainer;
            }
            set
            {
                if (BarcodeOverlayContainer != value)
                {
                    barcodeOverlayContainer = value;
                    OnPropertyChanged(nameof(BarcodeOverlayContainer));
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

        /// <summary>
        /// Separate each three digits by period '.'
        /// </summary>
        /// <param name="barcodeText">A string representation of the barcode result</param>
        /// <returns> The passed argument splitted by period between each 3 of its digits</returns>
        private string SplitDigitsByPeriod(string barcodeText)
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

#endregion : Scanner


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
