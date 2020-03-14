using System;
using System.ComponentModel;

namespace IkeaStore.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public HomeViewModel()
        {
        }

        // Search list view specific logic

            private bool isSearchListActive = false;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
