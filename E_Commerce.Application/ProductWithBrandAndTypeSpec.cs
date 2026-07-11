using E_Commerce.Application.Specifications;
using E_Commerce.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public class ProductWithBrandAndTypeSpec : BaseSpecification<Product , int>
    {
        public ProductWithBrandAndTypeSpec():base(null)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.ProductType);
        }
        public ProductWithBrandAndTypeSpec(int id):base(P => P.Id == id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.ProductType);
        }
    }
}
