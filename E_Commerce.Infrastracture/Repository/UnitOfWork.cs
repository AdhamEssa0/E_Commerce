using E_Commerce.Doman.Commen;
using E_Commerce.Doman.Contracts;
using E_Commerce.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture.Repository
{
    public class UnitOfWork(StoreDbContext dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TypeName = typeof(TEntity).Name;
            if (repositories.TryGetValue(TypeName, out object? value))
                return (IGenericRepository<TEntity, TKey>) value;
            else
            {
                var repo = new GenericRepository<TEntity, TKey>(dbContext);
                repositories[TypeName] = repo;
                return repo;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
            => await dbContext.SaveChangesAsync(ct);
    }
}
