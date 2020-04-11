using System;
using IkeaStore.Models;
using Xamarin.Forms;

namespace IkeaStore.Views.Components
{
    public class CarouselViewArticleTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AllArticlesView { get; set; }
        public DataTemplate ArticleSummaryView { get; set; }

        public CarouselViewArticleTemplateSelector()
        {
            AllArticlesView = new DataTemplate(typeof(NavigateToAllArticles));
            ArticleSummaryView = new DataTemplate(typeof(ArticleOverview));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Article product = (Article)item;

            // When the carousel view reaches the last element in its items source, use the AllArticlesView template
            if (product.IsLastItemInArticles)
            {
                return AllArticlesView;
            }
            // Otherwise use ArticleSummaryView template
            else
            {
                return ArticleSummaryView;
            }
        }
    }
}
