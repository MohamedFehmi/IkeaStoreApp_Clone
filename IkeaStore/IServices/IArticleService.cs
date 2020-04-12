using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IkeaStore.Models;

namespace IkeaStore.IServices
{
    public interface IArticleService
    {
        // Get articles list of type : New articles ("products")
        Task<List<Article>> GetNewArticles();

        // Get articles list of type : Poluar
        Task<List<Article>> GetPopularArticles();

        // Get article by ID
        Task<Article> GetArticleByID(string ID);
    }
}
