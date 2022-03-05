using Blok.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Core
{

    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        Task<int> CommitAsync();
    }
}
