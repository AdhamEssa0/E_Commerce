using E_Commerce.Doman.Commen;
using E_Commerce.Doman.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture.Specification
{
    public static class SpecificationEvaluatar
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> enterypoint,
                                                                        Ispecification<TEntity, TKey> spec) where TEntity : BaseEntity<TKey>
        {
            // 1. Entry Point
            var query = enterypoint;
            // dbcontext.Set<TEntity>().Where()
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            // 3. Includes
            query = spec.InclodeExpression.Aggregate(query, (current, nextExp) => current.Include(nextExp));
            return query;
        }
        
    }
}
