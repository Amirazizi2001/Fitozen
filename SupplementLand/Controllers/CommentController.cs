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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;
        public CommentController(ICommentService commentService, IProductService productService)
        {
            _commentService = commentService;
            _productService = productService;
        }
        [Authorize]
        [HttpGet("GetCommentById/{id}")]
        public async Task<IActionResult> getcommentById(int id)
        {
            var comment=await _commentService.GetCommentById(id);
            return Ok(comment);
        }
        
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment(CommentDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            await _commentService.AddComment(dto,userId);
            return Ok("Comment added successfully");
        }
       
        [HttpDelete("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var exist = await _commentService.GetCommentById(id);
            if (exist == null) { return NotFound("Comment doesn't exist"); }
            await _commentService.DeleteComment(id);
            return Ok("Comment Deleted successfully");
        }
        
        [HttpPut("EditComment")]
        public async Task<IActionResult> EditComment([FromBody]ComUpdateDto dto)
        {
            await _commentService.EditComment(dto);
            return Ok("Comment updated successfully");
        }
        [HttpGet("GetProductComments")]
        public async Task<IActionResult> GetProductComments([FromQuery]CommentFilter filter)
        {
            var comments = await _productService.GetProductComments(filter);
            return Ok(comments);
        }
        [HttpPost("ReplyToComment")]
        public async Task<IActionResult> ReplyToComment(CommentDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("Invalid token");

            var userId = int.Parse(userIdClaim.Value);
            var result=await _commentService.ReplyToComment(dto,userId);
            if(!result.Success) {return BadRequest(result.Message);}
            return Ok(result);  
        }

    }
}
