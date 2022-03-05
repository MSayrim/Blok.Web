using Blok.Core.Models;
using Blok.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDBContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Article>> GetAllWithArticlesAsync()
        {
            return await BlogDBContext.Articles
                .Include(a => a.Categories)
                .ToListAsync();
        }

        public async Task<Article> GetWithArticlesByIdAsync(int id)
        {
            return await BlogDBContext.Articles
                .Include(a => a.Categories)
                .SingleOrDefaultAsync(a => a.ID == id);
        }

        private BlogDBContext BlogDBContext
        {
            get { return Context as BlogDBContext; }
        }
    }
}
