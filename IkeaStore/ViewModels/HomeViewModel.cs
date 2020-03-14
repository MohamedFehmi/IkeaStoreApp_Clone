using System;
using System.ComponentModel;

namespace IkeaStore.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public HomeViewModel()
        {
        }

        #region: Header view

            // Search list logic
            private bool isSearchListActive;

            public bool IsSearchListActive
            {
                get
                {
                    return isSearchListActive;
                }

                set
                {
                    // Only update value when it is different than the new one
                    if (isSearchListActive != value)
                    {
                        isSearchListActive = value;

                        OnPropertyChanged(nameof(IsSearchListActive));
                    }
                }
            }

            // Scan barcode button logic
            private bool isScanBarcodeBtnVisible;

            public bool IsScanBarcodeBtnVisible
            {
                    get
                    {
                        return isScanBarcodeBtnVisible;
                    }

                    set
                    {
                        // Only update value when it is different than the new one
                        if (isScanBarcodeBtnVisible != value)
                        {
                            isScanBarcodeBtnVisible = value;

                            OnPropertyChanged(nameof(IsScanBarcodeBtnVisible));
                        }
                    }
            }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
