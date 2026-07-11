using E_Commerce.Doman.Commen;
using E_Commerce.Doman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Specifications
{
    public class BaseSpecification<TEntity, TKey> : Ispecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public ICollection<Expression<Func<TEntity, object>>> InclodeExpression { get; } = [];

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            InclodeExpression.Add(include);
        }
        public BaseSpecification(Expression<Func<TEntity , bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
