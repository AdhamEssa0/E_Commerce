using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public class ProductQueryParms
    {
        public int? BarndId { get; set; }
        public int? TypeId { get; set; }
        public string? Searsh { get; set; }
        public ProductSortObjects Sort { get; set; }

        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 10;
        private const int DefaultPageSize = 5;

        private int pageSize;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : (value < 1 ? DefaultPageSize : value);
        }
    }
}
