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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetDiscounts")]
        public async Task<IActionResult> GetDiscounts([FromQuery]DiscountFilter filter)
        {
            var discounts = await _discountService.GetDiscounts(filter);
            return Ok(discounts);
        }

        [HttpPost("AddDiscount")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDiscount(DiscountDto dto)
        {
            await _discountService.AddDiscount(dto);
            return Ok("Discount added successfully");
        }

        [HttpPut("UpdateDiscount")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDiscount([FromBody]UDiscountDto dto)
        {
            var discount = await _discountService.GetDiscountById(dto.Id);
            if (discount == null) return NotFound();

            await _discountService.UpdateDiscount(dto);
            return Ok("Discount updated successfully");
        }

        [HttpDelete("DeleteDiscount/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var discount = await _discountService.GetDiscountById(id);
            if (discount == null) return NotFound();

            await _discountService.DeleteDiscount(id);
            return Ok("Discount deleted successfully");
        }
    }
}

