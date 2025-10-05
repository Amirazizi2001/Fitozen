using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using System.Runtime.InteropServices;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly IFactoryService _factoryService;
        public FactoriesController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }
        [HttpGet("GetAllFactories")]
        public async Task<IActionResult> GetAllFactories([FromQuery]Filter filter)
        {
            var factories=await _factoryService.GetFactoriesList(filter);
            return Ok(factories);
        }
        [HttpGet("Factory-Get-Products")]
        public async Task<IActionResult> GetFactoryProducts([FromQuery]FactoryFilter filter)
        {
            var factories=await _factoryService.GetFactoryProductsList(filter);
            return Ok(factories);
        }
        


    }
}
