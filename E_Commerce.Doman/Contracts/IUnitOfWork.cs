using E_Commerce.Doman.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doman.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct =  default);
        IGenericRepository<TEntity , TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
