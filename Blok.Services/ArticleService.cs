using Blok.Core;
using Blok.Core.Models;
using Blok.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Services
{
    public class ArticleService:IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Article> CreateArticle(Article newArticle)
        {
            await _unitOfWork.Articles
                .AddAsync(newArticle);

            return newArticle;
        }

        public async Task DeleteArticle(Article artist)
        {
            _unitOfWork.Articles.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return await _unitOfWork.Articles.GetAllAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _unitOfWork.Articles.GetByIdAsync(id);
        }

        public async Task UpdateArticle(Article artistToBeUpdated, Article article)
        {
            artistToBeUpdated.Title = article.Title;

            await _unitOfWork.CommitAsync();
        }
    }
}
