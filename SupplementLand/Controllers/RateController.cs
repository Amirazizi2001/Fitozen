using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using System.Security.Claims;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }
        [HttpGet("GetProductRates")]
        public async Task<IActionResult> GetProductRates([FromQuery]RateFilter filter)
        {
            var rates = await _rateService.GetProductRates(filter);
            return Ok(rates);
        }
        [HttpPost("AddRate")]
        public async Task<IActionResult> AddRate(RateDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            await _rateService.AddRate(dto,userId);
            return Ok("Rate added successfully");
        }
        [HttpDelete("DeleteRate/{id}")]
        public async Task<IActionResult> DeleteRate(int id)
        {
            var rate = await _rateService.GetRateById(id);
            if (rate == null) { return NotFound(); }
            ;
            await _rateService.DeleteRate(id);
            return Ok("Rate deleted successFully");
        }
        [HttpPut("UpdateRate")]
        public async Task<IActionResult> UpdateRate([FromBody] URateDto dto)
        {
            var rate =await _rateService.GetRateById(dto.Id);
            if (rate == null) { return NotFound(); }
            ;
            await _rateService.UpdateRate(dto);
            return Ok("rate updated successfully");
        }
    }
}
