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
            var orders = await _orderService.GetOrders(filter);
            return Ok(orders);
        }
        [HttpGet("GetOrderDetail/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var order = await _orderService.GetOrderDetail(id);
            return Ok(order);
        }
        [HttpGet("GetUserProfile/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _userService.GetUserProfile(id);
            return Ok(user);
        }
        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfile(UserProfileDto dto)
        {
            var result = await _userService.UpdateUserProfile(dto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);


        }
    }
}
