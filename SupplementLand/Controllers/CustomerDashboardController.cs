using Microsoft.AspNetCore.Authorization;
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
    public class CustomerDashboardController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public CustomerDashboardController(IOrderService orderService, IUserService userService)
        {
            _userService = userService;
            _orderService = orderService;
        }
        [HttpGet("GetUserOrder")]
        [Authorize]
        public async Task<IActionResult> GetUserOrders([FromQuery] OrderFilter filter)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var orders = await _orderService.GetOrders(filter, userId);
            return Ok(orders);
        }
        [HttpGet("GetOrderDetail/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var order = await _orderService.GetOrderDetail(id);
            return Ok(order);
        }
        [HttpGet("GetUserProfile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var user = await _userService.GetUserProfile(userId);
            return Ok(user);
        }
        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfile(UserProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.UpdateUserProfile(dto, userId);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);


        }
    }
}
