using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPhotoController : ControllerBase
    {
        private readonly IFactoryService _factoryService;
        private readonly IProductService _productservice;
        private readonly IConfiguration _configuration;
        public AddPhotoController(IFactoryService factoryService,IProductService productservice,IConfiguration configuration)
        {
            _factoryService = factoryService;
            _productservice = productservice;
            _configuration = configuration;
        }
        [HttpPost("AddFactoryImage")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UploadFactoryImage(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var folder = _configuration["ImageSettings:StoragePath"];
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            
            var relativePath = $"/images/factories/{fileName}";
            var factory=await _factoryService.GetFactoryById(id);
            var dto = new FacImageDto
            {
                FactoryId=factory.Id,
                ImageUrl=relativePath,
            };
            
           var result= await _factoryService.AddFactoryImage(dto);
            if (!result.Success) { return BadRequest("Image wasn't add"); }
            return Ok(result.Message);

            
            
        }
        [HttpPost("AddProductImage")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UploadProductImage(int id, List<IFormFile> files)
        {
            if (files == null || files.Count != 3)
                return BadRequest("Exactly 3 images are required.");

            var folder = _configuration["ImageSettings:StoragePath"];
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var product = await _productservice.GetProductById(id);
            if (product == null)
                return NotFound();

            var path = new List<string>();
           
            foreach (var file in files)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                path.Add($"/images/products/{fileName}");

                
            }

            // انتساب به فیلدهای محصول
            

           
            
           
            var dto = new ProductImageDto
            {
                ProductId= id,
                ImageUrl1 = path[0],
                ImageUrl2 = path[1],
                ImageUrl3 = path[2],
            };

            var result = await _productservice.AddProductImage(dto);
            if (!result.Success) { return BadRequest("Image wasn't add"); }
            return Ok(result.Message);



        }
    }
}
