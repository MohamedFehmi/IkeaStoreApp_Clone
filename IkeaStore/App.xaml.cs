using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IkeaStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
