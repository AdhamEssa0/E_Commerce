using E_Commerce.Doman.Commen;
using E_Commerce.Doman.Contracts;
using E_Commerce.Infrastracture.Data;
using E_Commerce.Infrastracture.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture.Repository
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public void Add(TEntity entity) => dbContext.Set<TEntity>().Add(entity);

        public async Task<int> CountAsync(Ispecification<TEntity, TKey> spec, CancellationToken ct = default)
        {
            return await SpecificationEvaluatar.CreateQuery(dbContext.Set<TEntity>(), spec).CountAsync();
        }

        public  async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await dbContext.Set<TEntity>().ToListAsync(ct);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(Ispecification<TEntity, TKey> spec, CancellationToken ct = default)
        {
            var query  = SpecificationEvaluatar.CreateQuery(dbContext.Set<TEntity>() , spec);

            return await query.ToListAsync(ct);
        }

        public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken ct = default)
        => await dbContext.Set<TEntity>().FindAsync(id, ct);

        public async Task<TEntity?> GetByIdAsync(Ispecification<TEntity, TKey> Spec, CancellationToken ct = default)
        {
            var query = SpecificationEvaluatar.CreateQuery(dbContext.Set<TEntity>(), Spec);
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(TEntity entity) => dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => dbContext.Set<TEntity>().Update(entity);
    }
}
