using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IkeaStore.ViewModels;
using Xamarin.Forms;

namespace IkeaStore.Views.Components
{
    public partial class TabbedView : ContentView
    {
        private TabbedViewViewModel tabbedViewViewModel;

        int selectedIndex = 0;

        List<Label> tabHeaders = new List<Label>();
        List<VisualElement> tabContents = new List<VisualElement>();

        public TabbedView()
        {
            InitializeComponent();

            // Setting the binding context
            tabbedViewViewModel = Resources["vm"] as TabbedViewViewModel;
            this.BindingContext = tabbedViewViewModel;

            // Retrieve the tab elements
            tabHeaders.Add(OffersTab);
            tabHeaders.Add(NewProductsTab);
            tabHeaders.Add(PopularTab);
        }

        private async void TabBar_Selected(System.Object sender, System.EventArgs e)
        {
            // Get the selected tab
            var tabIndex = tabHeaders.IndexOf((Label)sender);

            // Update the UI to unselect old tab and select the new one
            await UpdateSelection(tabIndex);
        }

        private async Task UpdateSelection(int newIndex)
        {
            // Ignore selection on the same selected tab
            if (newIndex == selectedIndex) return;

            // Get the selected tab
            var selectedTabLabel = tabHeaders[newIndex];

            // Translate the selection underline
            _ = SelectionUnderline.TranslateTo(selectedTabLabel.Bounds.X, 0, 150, easing: Easing.SinInOut);

            // Update the style of the selected tab

            // Update the content


            selectedIndex = newIndex;
        }
    }
}
