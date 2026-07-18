using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.BaskerDTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class BasketController : ApiBaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        // GET ::BaseUrl/api/Basket/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string id , CancellationToken ct)
        {
            var result = await _basketService.GetBasketAsync(id, ct);
            return ToActionResult(result);
        }

        // POST ::BaseUrl/api/Basket => {Body}
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CraeteOrUpdateBasket(BasketDto basket , CancellationToken ct )
        {
            var result = await _basketService.CraeteOrUpdateBasketAsync(basket , ct:ct); 
            return ToActionResult(result);
        }
        // DELETE ::BaseUrl/api/Basket/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string id , CancellationToken ct)
        {
            var result = await _basketService.DeleteBAsketAsync(id, ct);
            return ToActionResult(result);
        }

    }
}
