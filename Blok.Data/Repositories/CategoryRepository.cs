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
    internal class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDBContext context)
          : base(context)
        { }

        public async Task<IEnumerable<Category>> GetAllWithCategoriesAsync()
        {
            return await BlogDBContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetWithCategoriesByIdAsync(int id)
        {
            return await BlogDBContext.Categories.Where(a=>a.ID==id).ToListAsync();
        }


        private BlogDBContext BlogDBContext
        {
            get { return Context as BlogDBContext; }
        }

    }
}
