using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace IkeaStore.ViewModels
{
    public class ScannerViewModel : INotifyPropertyChanged
    {
        public ICommand ExitBarcodeScanner { get; private set; }
        
        public ScannerViewModel()
        {
            ExitBarcodeScanner = new Command(ExitScanner);
        }

        public void ExitScanner()
        {
            Shell.Current.Navigation.PopModalAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
