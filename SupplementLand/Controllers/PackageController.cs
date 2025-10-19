using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("GetPackages")]
        public async Task<IActionResult> GetPackages([FromQuery]PackageFilter filter)
        {
            var packages = await _packageService.GetPackages(filter);
            return Ok(packages);
        }

        [HttpPost("AddPackage")]
        public async Task<IActionResult> AddPackage(PackageDto dto)
        {
            await _packageService.AddPackage(dto);
            return Ok("Package added successfully");
        }

        [HttpPut("UpdatePackage")]
        public async Task<IActionResult> UpdatePackage([FromBody] UPackageDto dto)
        {
            var package = await _packageService.GetPackageById(dto.Id);
            if (package == null) return NotFound();

            await _packageService.UpdatePackage(dto);
            return Ok("Package updated successfully");
        }

        [HttpDelete("DeletePackage/{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            var package = await _packageService.GetPackageById(id);
            if (package == null) return NotFound();

            await _packageService.DeletePackage(id);
            return Ok("Package deleted successfully");
        }
    }
}
