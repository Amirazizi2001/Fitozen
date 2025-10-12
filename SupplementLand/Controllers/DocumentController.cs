using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;
    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    
    [HttpPost("upload")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UploadDocument(IFormFile file, int? factoryId, int? productId)
    {
        if (file == null || file.Length == 0)
            return BadRequest("فایلی ارسال نشده است.");

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);

        var dto = new DocumentDto
        {
            FileName = file.FileName,
            ContentType = file.ContentType,
            Data = ms.ToArray(),
            FactoryId = factoryId,
            ProductId = productId
        };

        var result = await _documentService.AddDocumentAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDocument(Guid id)
    {
        var doc = await _documentService.GetDocumentAsync(id);
        if (doc == null)
            return NotFound();

        return File(doc.Data, doc.ContentType, doc.FileName);
    }

    
    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download(Guid id)
    {
        var doc = await _documentService.GetDocumentAsync(id);
        if (doc == null)
            return NotFound("فایل مورد نظر یافت نشد.");

        
        var contentDisposition = new System.Net.Mime.ContentDisposition
        {
            FileName = doc.FileName,
            Inline = false 
        };
        Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

        return File(doc.Data, doc.ContentType, doc.FileName);
    }
}
