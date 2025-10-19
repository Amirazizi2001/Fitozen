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
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        

        [HttpPost("AddOffer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOffer(OfferDto dto)
        {
            await _offerService.AddOffer(dto);
            return Ok("Offer added successfully");
        }

        [HttpPut("UpdateOffer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOffer([FromBody]UOfferDto dto)
        {
            var offer = await _offerService.GetOfferById(dto.Id);
            if (offer == null) return NotFound();

            await _offerService.UpdateOffer(dto);
            return Ok("Offer updated successfully");
        }

        [HttpDelete("DeleteOffer/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _offerService.GetOfferById(id);
            if (offer == null) return NotFound();

            await _offerService.DeleteOffer(id);
            return Ok("Offer deleted successfully");
        }
    }
}
