using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Infrastructure.Services;
using System.Security.Claims;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        

        public OrderController(IOrderService orderService, IPortfolioService portfolioService)
        {
            _orderService = orderService;
            
        }
        [HttpGet("GetOrders")]
        [Authorize]
        public async Task<IActionResult> GetOrders([FromQuery]OrderFilter filter)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            
            var orders = await _orderService.GetOrders(filter,userId);
            return Ok(orders);
        }
        [HttpPost("AddOrder")]
        [Authorize]
        public async Task<IActionResult> AddOrder(OrderDto dto)
        {
            var result=await _orderService.AddOrder(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }
        [HttpGet("GetOrderProductDetail/{portfolioId}")]
        [Authorize]
        public async Task<IActionResult> GetOrderProductDetail(int portfolioId)
        {
            var details=await _orderService.GetOrderProductDetail(portfolioId);
            return Ok(details);
        }
        [HttpPut("CancelOrder/{orderId}")]
        [Authorize]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var result = await _orderService.CancelOrder(orderId);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
    }
}
