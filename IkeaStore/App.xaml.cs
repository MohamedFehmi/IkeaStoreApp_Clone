using IkeaStore.Managers;
using Xamarin.Forms;

namespace IkeaStore
{
    public partial class App : Application
    {
        public static ServiceInstanceManager instanceManager;

        public App()
        {
            InitializeComponent();

            // In production mode or a buisiness project, avoid Experimental mode and only use stable components

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
