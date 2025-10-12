using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;

namespace SupplementLand.Infrastructure.Services;

public class PortfolioService : IPortfolioService
{
    private readonly SupplementLandDb _context;

    public PortfolioService(SupplementLandDb context)
    {
        _context = context;
    }

    public async Task<OperationResult> AddItem(portfolioItemDto dto)
    {
        try
        {
            var item = new PortfolioItem
            {
                PortfolioId = dto.PortfolioId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                VariantId= dto.VariantId,
            };

            await _context.portfolioItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Item added to portfolio successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error adding item: {ex.Message}" };
        }
    }

    public async Task<OperationResult> CreatePortfolio(PortfolioDto dto)
    {
        try
        {
            var portfolio = new Portfolio
            {
                Name = dto.Name,
                UserId = dto.UserId,
                CreateDate = dto.CreateDate,
                DeleteDate = dto.DeleteDate,
                status = dto.status
            };

            await _context.portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Portfolio created successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error creating portfolio: {ex.Message}" };
        }
    }

    public async Task<OperationResult> DeleteItem(int portfolioItemId)
    {
        var item = await GetPortfolioItem(portfolioItemId);
        if (item == null)
            return new OperationResult { Success = false, Message = "Portfolio item not found" };

        _context.portfolioItems.Remove(item);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Portfolio item deleted successfully" };
    }

    public async Task<OperationResult> DeletePortfolio(int portfolioId)
    {
        var portfolio = await GetPortfolioById(portfolioId);
        if (portfolio == null)
            return new OperationResult { Success = false, Message = "Portfolio not found" };

        _context.portfolios.Remove(portfolio);
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Portfolio deleted successfully" };
    }

    public async Task<Portfolio> GetPortfolioById(int id)
    {
        return await _context.portfolios.FindAsync(id);
    }

    public async Task<PortfolioItem> GetPortfolioItem(int portfolioItemId)
    {
        return await _context.portfolioItems.FindAsync(portfolioItemId);
    }

    public async Task<DataResult<PIListDto>> GetPortfolioItems(PortfolioItemFilter filter)
    {
        IQueryable<PortfolioItem> query = _context.portfolioItems.Include(pi=>pi.Product).AsQueryable();

        if (filter.PortfolioId.HasValue)
            query = query.Where(pi => pi.PortfolioId == filter.PortfolioId.Value);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(pi => new PIListDto
            {
                Name = pi.Product.Name,
                Price = pi.Product.Price,
                Quantity = pi.Quantity,
                VariantId = pi.VariantId,
                DocumentIds=pi.Product.Documents.Select(pi=>pi.Id).ToList(),
                
            })
            .ToListAsync();

        return new DataResult<PIListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<decimal> PortfolioTotalSum(int portfolioId)
    {
        var totalPrice = await _context.portfolioItems
            .Include(pi => pi.Product)
            .Where(pi => pi.PortfolioId == portfolioId)
            .SumAsync(pi => pi.Product.Price * pi.Quantity);

        return totalPrice;
    }
}

