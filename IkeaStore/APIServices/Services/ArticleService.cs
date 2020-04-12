using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IkeaStore.IServices;
using IkeaStore.Models;

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

        public Task<Article> GetArticleByID(string ID)
        {
            try
            {
                return Task.FromResult(new Article());
            }
            catch (Exception e)
            {
                return Task.FromResult(new Article());
            }
        }

        public Task<List<Article>> GetNewArticles()
        {
            try
            {

                return Task.FromResult(new List<Article>());
            }
            catch (Exception e)
            {
                return Task.FromResult(new List<Article>());
            }
        }

        public Task<List<Article>> GetPopularArticles()
        {
            try
            {
                return Task.FromResult(new List<Article>());
            }
            catch (Exception e)
            {
                return Task.FromResult(new List<Article>());
            }
        }
    }
}
