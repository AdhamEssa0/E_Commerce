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

            switch (queryParams.Sort)
            {
                case ProductSortObjects.NameAsc:
                    AddOrderBy(P => P.Name);
                    break;
                case ProductSortObjects.NameDesc:
                    AddOrderByDesc(P => P.Name);
                    break;
                case ProductSortObjects.PriceAsc:
                    AddOrderBy(P => P.Price);
                    break;
                case ProductSortObjects.PriceDesc:
                    AddOrderByDesc(P => P.Price);
                    break;
                default:
                    AddOrderBy(P => P.Id);
                    break;
            }
            // Pagination
            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }
        public ProductWithBrandAndTypeSpec(int id):base(P => P.Id == id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.ProductType);
        }
    }
}
