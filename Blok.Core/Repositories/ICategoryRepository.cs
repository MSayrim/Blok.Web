using Blok.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithCategoriesAsync();
        Task<IEnumerable<Category>> GetWithCategoriesByIdAsync(int id);
    }
}
