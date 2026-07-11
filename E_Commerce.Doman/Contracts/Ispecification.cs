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
        ICollection<Expression<Func<TEntity , Object>>> InclodeExpression {  get;}
        Expression<Func<TEntity , bool>> Criteria {  get;}
    }
}
