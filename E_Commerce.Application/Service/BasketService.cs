using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.BaskerDTOs;
using E_Commerce.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<Result<BasketDto>> CraeteOrUpdateBasketAsync(BasketDto basket, TimeSpan? TLV = null, CancellationToken ct = default)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var basketResult = await _basketRepository.CreateOrUpdateBasAsync(customerBasket, TLV , ct);
            return basketResult == null ? Result<BasketDto>.Fail(Error.Failure("Failed to create or update basket"))
                : Result<BasketDto>.Ok(basket);
        }

        public async Task<Result<bool>> DeleteBAsketAsync(string basketId, CancellationToken ct = default)
        {
            var result = await _basketRepository.DeleteBasketAsync(basketId, ct);
            return result ? Result<bool>.Ok(true) : Result<bool>.Fail(Error.Failure("Failed to delete basket !!"));
        }

        public async Task<Result<BasketDto>> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket  = await _basketRepository.GetBasketAsync(basketId, ct);
            return basket == null ? Result<BasketDto>.Fail(Error.Failure("Failed to get basket"))
                : Result<BasketDto>.Ok(_mapper.Map<BasketDto>(basket));
        }
    }
}
