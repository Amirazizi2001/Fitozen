using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Infrastructure.Filters;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPortfolioService _portfolioService;
        public ProductsController(IProductService productService,IPortfolioService portfolioService)
        {
            _productService = productService;
            _portfolioService = portfolioService;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery]ProductFilter filter)
        {
            var producs = await _productService.GetProducts(filter);
            return Ok(producs);
        }
        [HttpGet("GetProductDetail/{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var product=await _productService.GetProductDetail(id);
            return Ok(product);
        }
        [HttpPost("AddProductToPortfolio")]
        [Authorize]
        public async Task<IActionResult> AddProductToPortfolio(portfolioItemDto dto)
        {
            var result = await _portfolioService.AddItem(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        
        
    }
}
