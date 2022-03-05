using Blok.Core;
using Blok.Core.Repositories;
using Blok.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDBContext _context;
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(BlogDBContext context)
        {
            this._context = context;
        }

        public IArticleRepository Articles => _articleRepository = _articleRepository ?? new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
