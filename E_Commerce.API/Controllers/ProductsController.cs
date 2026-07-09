using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // Get All Product 
        // GET :: BaseUrl/api/Product
        [HttpGet]
        public async Task<ActionResult<Result<IReadOnlyList<ProductDto>>>> GetAllProducts(CancellationToken ct = default!)
        {
            var result = await _productService.GetAllProductsAsync(ct);
            return Ok(result);
        }

        // GET :: Product by id
        // GET :: BaseUrl/api/Product/{Id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<ProductDto>>> GetProduct(int id , CancellationToken ct)
        {
            var result = await _productService.GetProductsAsync(id, ct);
            return Ok(result);
        }
        // GET All brands
        // GET :: BaseUrl/api/Product/brands
        [HttpGet("brands")]
        public async Task<ActionResult<Result<IReadOnlyList<BrandDto>>>> GetAllBrands(CancellationToken ct = default!)
        {
            var brands = await _productService.GetAllBrandsAsync(ct);
            return Ok(brands);
        } 
        
        // GET All types
        // GET :: BaseUrl/api/Product/types
        [HttpGet("types")]
        public async Task<ActionResult<Result<IReadOnlyList<TypeDto>>>> GetAllTypes(CancellationToken ct = default!)
        {
            var types = await _productService.GetAllTypeAsync(ct);
            return Ok(types);
        }

    }
}
