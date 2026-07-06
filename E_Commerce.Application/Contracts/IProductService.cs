using E_Commerce.Application.DTOs.ProductDtos;
using E_Commerce.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Contracts
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync(CancellationToken ct = default);
    }
}
