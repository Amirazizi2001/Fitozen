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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductFilter filter)
        {
            var products=await _productService.GetProducts(filter);
            return Ok(products);
        }
        
        
        [HttpDelete("DeleteProduct/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
           var result= await _productService.DeleteProduct(id);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        
        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            var result=await _productService.AddProduct(productDto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);

        }
        
        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody]PUpdateDto pUpdateDto)
        {
            var result=await _productService.UpdateProduct(pUpdateDto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpGet("GetProductComments")]
        public async Task<IActionResult> GetProductcomments([FromQuery]CommentFilter filter)
        {
            var comments=await _productService.GetProductComments(filter);
            return Ok(comments);
        }
        [HttpPost("AddVariant")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProductVariant(ProductsVariantDto dto)
        {
            var result = await _productService.AddProductVariant(dto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpPost("AddSupplementFact")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddSupplementFact(SupplementFactsDto dto)
        {
            var result = await _productService.AddSupplementFact(dto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpDelete("DeleteVariant/{id}")]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            var result = await _productService.DeleteVariant(id);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpDelete("DeleteSupplementFact/{id}")]
        public async Task<IActionResult> DeleteSupplementFact(int id)
        {
            var result = await _productService.DeleteSupplementFacts(id);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }

    }
}
