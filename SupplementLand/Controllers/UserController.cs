using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System.Security.Claims;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] UserFilter filter)
        {
            var users = await _userService.GetAllUsers(filter);
            return Ok(users);
        }

       

        [HttpGet("Portfolios")]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolios([FromQuery] PortfolioFilter filter)
        {
            var portfolios = await _userService.UserPortfolios(filter);
            return Ok(portfolios);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateDto updateDto)
        {
            var result = await _userService.UpdateUser(updateDto);

            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }

        [HttpGet("GetUserComments")]
        [Authorize]
        public async Task<IActionResult> GetUserComments([FromQuery] UserCommentFilter filter)
        {
            var comment = await _userService.GetUserComments(filter);
            return Ok(comment);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDto dto)
        {
            var result= await _userService.AddUser(dto);
            if (!result.Success) {return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpGet("GetOrderProductDetail/{portfolioId}")]
        public async Task<IActionResult> GetOrderProductDetail(int portfolioId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var detail = await _userService.GetOrderProductDetail(portfolioId,userId);
            return Ok(detail);
        }
        

    }
}
