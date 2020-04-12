using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IkeaStore.IServices;
using IkeaStore.Models;

namespace IkeaStore.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService()
        {
        }

        public Task<Article> GetArticleByID(string ID)
        {
            try
            {

            }
            catch (Exception e)
            {
                return new Article();
            }
        }

        public Task<List<Article>> GetNewArticles()
        {
            try
            {

            }
            catch (Exception e)
            {
                return new List<Article>();
            }
        }

        public Task<List<Article>> GetPopularArticles()
        {
            try
            {

            }
            catch (Exception e)
            {
                return new List<Article>();
            }
        }
    }
}
