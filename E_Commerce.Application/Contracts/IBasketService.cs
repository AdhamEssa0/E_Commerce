using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.BaskerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Contracts
{
    public interface IBasketService
    {
        // Get Basket
        Task<Result<BasketDto>> GetBasketAsync(string basketId, CancellationToken ct = default);
        
        // Create Basket
        Task<Result<BasketDto>> CraeteOrUpdateBasketAsync(BasketDto basket, TimeSpan? TLV = default ,CancellationToken ct = default);

        // Delete Basket
        Task<Result<bool>> DeleteBAsketAsync(string basketId, CancellationToken ct = default);
    }
}
