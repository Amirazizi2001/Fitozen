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

public class DiscountService:IDiscountService
{
    private readonly SupplementLandDb _context;

    public DiscountService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddDiscount(DiscountDto dto)
    {
        try
        {
            var discount = new Discount
            {
                Title = dto.Title,
                Code = dto.Code,
                Percentage = dto.Percentage,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            await _context.discounts.AddAsync(discount);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "comment updated successfully" } ;
        }
        catch (Exception ex)
        {
            return new OperationResult {Success=true, Message = "Error adding discount" };
        }
    }

    public async Task<OperationResult> UpdateDiscount(UDiscountDto dto)
    {
        var discount = await GetDiscountById(dto.Id);
        if (discount == null)
            return new OperationResult { Success = false, Message = "Discount not found" };

        discount.Percentage = dto.Percentage;
        discount.StartDate = dto.StartDate;
        discount.EndDate = dto.EndDate;

        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "discount updated successfully" } ;
    }

    public async Task<OperationResult> DeleteDiscount(int id)
    {
        var discount = await GetDiscountById(id);
        if (discount == null)
            return new OperationResult { Success = false, Message = "Discount not found" };


        _context.discounts.Remove(discount);
        await _context.SaveChangesAsync();
        return new OperationResult { Success = true, Message = "discount updated successfully" };
    }

    public async Task<Discount> GetDiscountById(int id)
    {
        return await _context.discounts.FindAsync(id);
    }

    public async Task<DataResult<DiscountListDto>> GetDiscounts(DiscountFilter filter)
    {
        IQueryable<Discount> query = _context.discounts.AsQueryable();

        if (filter.Title!=null)
            query = query.Where(d =>d.Title.Contains(filter.Title));

        var totalCount = await query.CountAsync();

        var items = await query.Select(d => new DiscountListDto
        {
            Id = d.Id,
            Title = d.Title,
            Code = d.Code,
            Percentage = d.Percentage,
            ProductName = d.Product != null ? d.Product.Name : null,
            PackageName = d.Package != null ? d.Package.Title : null,
            StartDate = d.StartDate,
            EndDate = d.EndDate
        })
        .Skip((filter.Page - 1) * filter.PageSize)
        .Take(filter.PageSize).AsNoTracking()
        .ToListAsync();

        return new DataResult<DiscountListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}

