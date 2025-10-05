using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(ContactDto dto)
        {
            var result=await _contactService.AddMessage(dto);
            if(!result.Success){return BadRequest(result.Message);}
            return Ok(result.Message);
        }
        [HttpPost("ReplyMessage")]
        public async Task<IActionResult> ReplyMesssage(ReplyDto dto)
        {
            var result=await _contactService.ReplyMessage(dto);
            if (!result.Success) { return BadRequest(result.Message); }
            return Ok(result.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ContactFilter filter)
        {
            var contacts = await _contactService.GetAllMessages(filter);
            return Ok(contacts);
        }
    }
}
