﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IkeaStore.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        // For the OnResume and SimulateStartup, refer to :
        // https://docs.microsoft.com/en-us/xamarin/android/user-interface/splash-screen

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => { StartupProcess(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void StartupProcess()
        {
            await Task.Delay(2000); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }
    }
}
