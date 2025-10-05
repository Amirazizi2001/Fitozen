using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryModalController : ControllerBase
    {
        private readonly ICatService _catService;
        public CategoryModalController(ICatService catService)
        {
            _catService = catService;
        }

        [HttpGet("GetCategories")]

        public async Task<IActionResult> GetCategories()
        {
            var categories = await _catService.GetCategories();
            return Ok(categories);
        }
    }
}
