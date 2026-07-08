using E_Commerce.Application.Common;
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
        Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDto>>> GetAllTypeAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default);
        Task<Result<ProductDto>> GetProductsAsync(int id ,CancellationToken ct = default);
    }
}
