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
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IUserService _userService;
        public PortfolioController(IPortfolioService portfolioService,IUserService userService)
        {
            _portfolioService = portfolioService;
            _userService = userService;
        }
        
        [HttpPost("CreatePortfolio")]
        [Authorize]
        public async Task<IActionResult> CreatePortfolio(PortfolioDto dto)
        {
            await _portfolioService.CreatePortfolio(dto);
            return Ok("Portfolio created successfully");
        }
        
        [HttpDelete("DeletePortfolio/{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeletePortfolio(id);
            return Ok("portfolio deleted successfully");
        }
        [Authorize]
        [HttpGet("GetPortfolioById/{id}")]
        public async Task<IActionResult> GetPortfolioById(int id)
        {
            var portfolio=await _portfolioService.GetPortfolioById(id);
            return Ok(portfolio);
        }
        
       
        [HttpPost("AddPortfolioItem")]
        [Authorize]
        public async Task<IActionResult> AddPortfolioItem(portfolioItemDto dto)
        {
            await _portfolioService.AddItem(dto);
            return Ok("PortfolioItem added successfully");
        }
        [Authorize]
        [HttpGet("GetPortfolioItemById/{id}")]
        public async Task<IActionResult> GetPortfolioItemById(int id)
        {
            var portfolioItem = await _portfolioService.GetPortfolioItem(id);
            return Ok(portfolioItem);
        }
        
        [HttpDelete("deletePortfolioItem/{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePortfolioItem(int id)
        {
            await _portfolioService.DeleteItem(id);
            return Ok("Item deleted successfully");
        }
      
        [HttpGet("GetPortfolioItems")]
        [Authorize]
        public async Task<IActionResult> GetPortfolioItem([FromQuery]PortfolioItemFilter filter)
        {
            var portfolioItems = await _portfolioService.GetPortfolioItems(filter);
            return Ok(portfolioItems);
        }
        
        [HttpGet("GetPortfolioTotalSum/{portfolioId}")]
        public async Task<IActionResult> GetPortfolioTotalSum(int portfolioId)
        {
            var price = await _portfolioService.PortfolioTotalSum(portfolioId);
            return Ok(price);
        }
        [HttpGet("GetCurrectPortfolio")]
        [Authorize]
        public async Task<IActionResult> GetCurrectPortfolio()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var user = await _userService.GetUserById(userId);
            if (user == null)
                return NotFound("User not found");

           var portfolio=await _portfolioService.GetUserPortfolio(userId);
            return Ok(portfolio);
        }
        [HttpPut("UpdatePortfolioItem")]
        [Authorize]
        public async Task<IActionResult> UpdatePortfolioItem(UPortfolioItemDto dto)
        {
            var result = await _portfolioService.UpdatePortfolioItem(dto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
    }
}
