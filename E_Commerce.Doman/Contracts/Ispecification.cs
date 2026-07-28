using E_Commerce.Doman.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doman.Contracts
{
    public interface Ispecification<TEntity , TKey> where TEntity :  BaseEntity<TKey>
    {
        // Includes
        ICollection<Expression<Func<TEntity , Object>>> InclodeExpression {  get;}
        // Where
        Expression<Func<TEntity , bool>> Criteria {  get;}
        // OrderBy
        Expression<Func<TEntity , Object>> OrderBy {  get;}
        Expression<Func<TEntity , Object>> OrderByDescending { get;}
        // Pagination
        int Skip { get; }
        int Take { get; }
        bool IsPagination { get; }

    }
}
