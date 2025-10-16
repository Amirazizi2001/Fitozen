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
            var orders = await _orderService.GetOrders(filter);
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
    }
}
