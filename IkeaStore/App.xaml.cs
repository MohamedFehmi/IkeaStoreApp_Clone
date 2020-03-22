﻿using IkeaStore.Managers;
using Xamarin.Forms;

namespace IkeaStore
{
    public partial class App : Application
    {
        public static ServiceInstanceManager instanceManager;

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });

            instanceManager = new ServiceInstanceManager();

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
