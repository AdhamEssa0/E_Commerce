using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // Get All Product 
        // GET :: BaseUrl/api/Product
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts(CancellationToken ct = default!)
        {
            var result = await _productService.GetAllProductsAsync(ct);
            return ToActionResult(result);

        }

        // GET :: Product by id
        // GET :: BaseUrl/api/Product/{Id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id , CancellationToken ct)
        {
            var result = await _productService.GetProductsAsync(id, ct);
            return ToActionResult(result);
        }
        // GET All brands
        // GET :: BaseUrl/api/Product/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAllBrands(CancellationToken ct = default!)
        {
            var brands = await _productService.GetAllBrandsAsync(ct);
            return ToActionResult(brands);

        }

        // GET All types
        // GET :: BaseUrl/api/Product/types
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypes(CancellationToken ct = default!)
        {
            var types = await _productService.GetAllTypeAsync(ct);
            return ToActionResult(types);

        }

    }
}
