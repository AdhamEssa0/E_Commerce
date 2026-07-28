using E_Commerce.Application.Common;
using E_Commerce.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Specifications
{
    public class ProducrCountSpecification : BaseSpecification<Product, int>
    {
        public ProducrCountSpecification(ProductQueryParms queryParams)
            : base(P => (!queryParams.BarndId.HasValue || P.BrandId == queryParams.BarndId.Value) &&
            (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId.Value)
            && (string.IsNullOrEmpty(queryParams.Searsh) || P.Name.ToLower().Contains(queryParams.Searsh.ToLower())))
        {

        }
    }
}
