using E_Commerce.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string  basketId , CancellationToken ct = default);
        Task<CustomerBasket> CreateOrUpdateBasAsync(CustomerBasket basket, TimeSpan? TimeLive = default , CancellationToken ct = default);
        Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default);
    }
}
