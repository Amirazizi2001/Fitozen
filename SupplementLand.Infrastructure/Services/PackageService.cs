using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;
public class PackageService:IPackageService
{

    private readonly SupplementLandDb _context;

    public PackageService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddPackage(PackageDto dto)
    {
        try
        {
            var package = new Package
            {
                Title = dto.Title,
                DiscountId = dto.DiscountId
            };

            var products = await _context.products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            package.Products = products;

            await _context.packages.AddAsync(package);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Package added successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error adding package: {ex.Message}" };
        }
    }

    public async Task<OperationResult> UpdatePackage(UPackageDto dto)
    {
        var package = await _context.packages
            .Include(p => p.Products)
            .FirstOrDefaultAsync(p => p.Id == dto.Id);

        if (package == null)
            return new OperationResult { Success = false, Message = "Package not found" };

        package.Title = dto.Title;
        package.DiscountId = dto.DiscountId;

        var products = await _context.products
            .Where(p => dto.ProductIds.Contains(p.Id))
            .ToListAsync();

        package.Products.Clear();
        foreach (var product in products)
            package.Products.Add(product);

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "Package updated successfully" };
    }

    public async Task<OperationResult> DeletePackage(int id)
    {
        var package = await GetPackageById(id);
        if (package == null)
            return new OperationResult { Success = false, Message = "Package not found" };

        _context.packages.Remove(package);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Package deleted successfully" };
    }

    public async Task<Package> GetPackageById(int id)
    {
        return await _context.packages.FindAsync(id);
    }

    public async Task<DataResult<PackageListDto>> GetPackages(PackageFilter filter)
    {
        IQueryable<Package> query = _context.packages.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(p => p.Title.Contains(filter.Title));

        var totalCount = await query.CountAsync();
        
        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(p => new PackageListDto
            {
                Id = p.Id,
                Title = p.Title,
                ProductNames = p.Products.Select(prod => prod.Name).ToList(),
                DiscountTitle = p.Discount != null ? p.Discount.Title : null,
                TotalPrice=p.Products.Sum(p=>p.Price)
            }).AsNoTracking()
            .ToListAsync();

        return new DataResult<PackageListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

   /* public async Task<OperationResult> ApplyPackageDiscount(string code, int packageId)
    {
       var discount=await _context.discounts.FirstOrDefaultAsync(d=>d.Code==code);
        if (discount == null) { return new OperationResult { Success = false,Message="Discount doesn't exist" }; }
        var percentage=discount.Percentage;
        var package=await _context.packages.FirstOrDefaultAsync(p=>p.Id==packageId);
        if (package == null) { return new OperationResult { Success = false, Message = "package doesn,t exist" }; }
        var products = package.Products;
        var totalPrice = products.Sum(p => p.Price);
        var discountedPrice=totalPrice-((totalPrice-percentage)/100);

    }*/
}
