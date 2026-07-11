using E_Commerce.Application.Common;
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
        public ProductWithBrandAndTypeSpec(ProductQueryParms queryParams) 
            :base(P => (!queryParams.BarndId.HasValue || P.BrandId == queryParams.BarndId.Value) &&
            (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId.Value)
            && (string.IsNullOrEmpty(queryParams.Searsh) || P.Name.ToLower().Contains(queryParams.Searsh.ToLower())))
            
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
