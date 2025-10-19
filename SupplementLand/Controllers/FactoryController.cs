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
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryService _factoryService;
        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }
        [HttpGet("GetAllFactories")]
        public async Task<IActionResult> GetAllFactories([FromQuery]Filter filter)
        {
            var factories=await _factoryService.GetAllFactories(filter);
            return Ok(factories);   
        }
        [HttpGet("GetFacById/{id}")]
        public async Task<IActionResult> GetFacById(int id)
        {
            var factory=await _factoryService.GetFactoryById(id);
            return Ok(factory);
        }
        [HttpGet("GetFacProducts")]
        public async Task<IActionResult> GetFacProducts([FromQuery]FactoryFilter filter)
        {
            var products=await _factoryService.GetFactoryProducts(filter);
            return Ok(products);
        }
        
        [HttpPost("AddFactory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFactory(FacDto facDto)
        {
           var result= await _factoryService.AddFactory(facDto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
      
        [HttpDelete("DeleteFactory/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            var result=await _factoryService.DeleteFactory(id);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        
        [HttpPut("UpdateFactory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFactory([FromBody]FUpdateDto facDto)
        {
            var result=await _factoryService.UpdateFactory(facDto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);

        }
    }
}
