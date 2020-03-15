using System;
using System.Collections.Generic;
using IkeaStore.Views.HomeGroup;
using Xamarin.Forms;

namespace IkeaStore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registering routes
            Routing.RegisterRoute("offerdetails", typeof(OfferDetailsPage));
        }
    }
}
