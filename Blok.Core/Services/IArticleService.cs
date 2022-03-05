using Blok.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Core.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> CreateArticle(Article newArticle);
        Task UpdateArticle(Article articleToBeUpdated, Article article);
        Task DeleteArticle(Article article);
    }
}
