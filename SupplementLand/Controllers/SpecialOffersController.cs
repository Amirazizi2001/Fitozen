using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using System.Net.WebSockets;
using System.Security.Claims;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public SpecialOffersController(IOfferService offersevice)
        {
            _offerService = offersevice;
        }
        [HttpGet("GetpecialOffers")]
        public async Task<IActionResult> GetOffers([FromQuery]Filter filter)
        {
            var offers = await _offerService.GetSpecialOffers(filter);
            return Ok(offers);
        }
        [HttpPost("AddOfferComment")]
        [Authorize]
        public async Task<IActionResult> AddOfferComment(int productId,CommentDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var result=await _offerService.AddOfferComment(productId, dto,userId);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);

        }
            
    }
}
