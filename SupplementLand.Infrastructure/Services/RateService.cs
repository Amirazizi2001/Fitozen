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

public class RateService : IRateService
{
    private readonly SupplementLandDb _context;

    public RateService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddRate(RateDto dto)
    {
        try
        {
            var rate = new Rate
            {
                Score = dto.Score,
                ProductId = dto.ProductId,
                UserId = dto.UserId
            };

            await _context.rates.AddAsync(rate);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Rate added successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error adding rate: {ex.Message}" };
        }
    }

    public async Task<OperationResult> UpdateRate(URateDto dto)
    {
        var rate = await GetRateById(dto.Id);
        if (rate == null)
            return new OperationResult { Success = false, Message = "Rate not found" };

        rate.Score = dto.Score;
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Rate updated successfully" };
    }

    public async Task<OperationResult> DeleteRate(int id)
    {
        var rate = await GetRateById(id);
        if (rate == null)
            return new OperationResult { Success = false, Message = "Rate not found" };

        _context.rates.Remove(rate);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Rate deleted successfully" };
    }

    public async Task<DataResult<RateListDto>> GetProductRates(RateFilter filter)
    {
        IQueryable<Rate> query = _context.rates.AsQueryable();

        if (!string.IsNullOrEmpty(filter.ProductName))
            query = query.Include(r=>r.Product).Include(r=>r.User).Where(r => r.Product.Name == filter.ProductName);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(r => new RateListDto
            {
                Id = r.Id,
                FullName = r.User.FullName,
                ProductName = r.Product.Name,
                Score = r.Score
            }).AsNoTracking().ToListAsync();

        return new DataResult<RateListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<Rate> GetRateById(int id)
    {
        return await _context.rates.FindAsync(id);
    }
}

