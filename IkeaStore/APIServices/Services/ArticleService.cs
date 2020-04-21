using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IkeaStore.IServices;
using IkeaStore.Models;
using Newtonsoft.Json;

namespace IkeaStore.Services
{
    public class ArticleService : IArticleService
    {
        private static ArticleService instance;
        public static ArticleService Instance
        {
            get
            {
                return instance != null ? instance : instance = new ArticleService();
            }
        }

        /// <summary>
        /// Search an article that matches the given ID
        /// </summary>
        /// <param name="ID">A unique string that represents the search creteria</param>
        /// <returns>
        ///     Object of type Article that represents :
        ///     1- The matched article with the given search criteria
        ///     2- An empty object in case the search is not found or error thrown
        /// </returns>
        public async Task<Article> GetArticleByID(string ID)
        {
            try
            {
                var listArticles = await GetNewArticles();

                var article = listArticles.Where(art => art.ID == ID).FirstOrDefault();

                return article;
            }
            catch (Exception e)
            {
                return new Article();
            }
        }

        /// <summary>
        /// Get the articles of type 'New'
        /// </summary>
        /// <returns>
        ///     A collection of Article object which type is 'New' or an empty collection
        ///     in case nothing articles with the given type do not exist in the server or an error has been thrown
        /// </returns>
        public async Task<List<Article>> GetNewArticles()
        {
            try
            {
                // Simulate server request
                await Task.Delay(100);

                var resultJSON = Dummies.NewArticles;

                var resultList = JsonConvert.DeserializeObject<List<Article>>(resultJSON);

                return resultList;
            }
            catch (Exception e)
            {
                return new List<Article>();
            }
        }

        /// <summary>
        /// Get the articles of type 'Popular'
        /// </summary>
        /// <returns>
        ///     A collection of Article object which type is 'Popular' or an empty collection
        ///     in case nothing articles with the given type do not exist in the server or an error has been thrown
        /// </returns>
        public async Task<List<Article>> GetPopularArticles()
        {
            try
            {
                // Simulate server request
                await Task.Delay(100);

                var resultJSON = Dummies.NewArticles;

                var resultList = JsonConvert.DeserializeObject<List<Article>>(JsonConvert.SerializeObject(resultJSON));

                return resultList;
            }
            catch (Exception e)
            {
                return new List<Article>();
            }
        }
    }
}
