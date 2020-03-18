using System;
using IkeaStore.Models;
using Xamarin.Forms;

namespace IkeaStore.Views.Components
{
    public class CarouselViewProductTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AllProductsView { get; set; }
        public DataTemplate ProductSummaryView { get; set; }

        public CarouselViewProductTemplateSelector()
        {
            AllProductsView = new DataTemplate(typeof(NavigateToAllProducts));
            ProductSummaryView = new DataTemplate(typeof(ProductOverview));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Product product = (Product)item;

            // When property toAllProcuts is set to true, use  the AllProductsView template
            if (product.IsLastItemInProducts)
            {
                return AllProductsView;
            }
            // Otherwise use ProductSummaryView template
            else
            {
                return ProductSummaryView;
            }
        }
    }
}
