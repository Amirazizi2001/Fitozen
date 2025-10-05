using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICatService _catService;
        public CategoryController(ICatService catService)
        {
            _catService = catService;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _catService.GetCategories();
            return Ok(categories);
        }
        
        
        [HttpPost("AddCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(CatDto catDto)
        {
            var result=await _catService.AddCategory(catDto);
            if(!result.Success) {return BadRequest(result.Message);}

            return Ok(result.Message);
        }
       
        [HttpDelete("DeleteCategory/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result=await _catService.DeleteCategory(id);
            if(!result.Success) { return BadRequest(result.Message);}

            return Ok(result.Message);
        }
       
        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(CUpdateDto cUpdateDto)
        {
           var result= await _catService.UpdateCategory(cUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
                return Ok(result.Message);
        }
        [HttpGet("GetCatProducts")]
        public async Task<IActionResult> GetCatProducts([FromQuery]CategoryFilter filter)
        {
            var products=await _catService.GetCatProducts(filter);
            return Ok(products);    
        }
        [HttpGet("GetCatChildern")]
        public async Task<IActionResult> GetCatChildern([FromQuery]CategoryFilter filter)
        {
            var childern=await _catService.GetChildrenCategories(filter);
            return Ok(childern);
        }
    }
}
