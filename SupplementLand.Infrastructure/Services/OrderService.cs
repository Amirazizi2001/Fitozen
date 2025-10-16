using Microsoft.EntityFrameworkCore;
using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SupplementLand.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly SupplementLandDb _context;
    private readonly IPortfolioService _portfolioService;

    public OrderService(SupplementLandDb context, IPortfolioService portfolioService)
    {
        _context = context;
        _portfolioService = portfolioService;
    }

    public async Task<OperationResult> AddOrder(OrderDto dto)
    {
        try
        {
            var order = new Order
            {
                PortfolioId = dto.PortfolioId,
                OrderDate = dto.OrderDate,
                Status = dto.Status
            };

            await _context.orders.AddAsync(order);
            var portfolio=await _portfolioService.GetPortfolioById(dto.PortfolioId);
            portfolio.status =Status.Ordered;
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Order created successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error creating order: {ex.Message}" };
        }
    }

    public async Task<DataResult<OrderListDto>> GetOrders(OrderFilter filter)
    {
        IQueryable<Order> query = _context.orders
            .Include(o => o.Portfolio)
                .ThenInclude(p => p.User)
            .Include(o => o.Portfolio)
                .ThenInclude(p => p.PortfolioItems)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Status))
            query = query.Where(o => o.Status.ToString() == filter.Status);

        if (filter.UserId.HasValue)
            query = query.Where(o => o.Portfolio.UserId == filter.UserId.Value);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(o => new OrderListDto
            {
                Id = o.Id,
                PortfolioId = o.PortfolioId,
                PortfolioName = o.Portfolio.Name ?? string.Empty,
                Status = o.Status.ToString(),
                OrderDate = o.OrderDate,
                UserId = o.Portfolio.UserId,
                CustomerName = o.Portfolio.User.FullName,
                TotalPrice = o.Portfolio.PortfolioItems!= null
                             ? o.Portfolio.PortfolioItems.Sum(p => p.Product.Price * p.Quantity)
                             : 0,
                Quantity = o.Portfolio.PortfolioItems != null
                           ? o.Portfolio.PortfolioItems.Sum(p => p.Quantity)
                           : 0
            }).AsNoTracking()
            .ToListAsync();

        return new DataResult<OrderListDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<OrderDetailDto> GetOrderDetail(int orderId)
    {
        var order = await _context.orders
            .Include(o => o.Portfolio)
            .ThenInclude(p => p.User)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null) return null;

        return new OrderDetailDto
        {
            Id = order.Id,
            PortfolioId = order.PortfolioId,
            Date = order.OrderDate,
            Status = order.Status.ToString(),
            UserId = order.Portfolio.UserId
        };
    }

    public async Task<OperationResult> CancelOrder(int orderId)
    {
        var order = await _context.orders.FindAsync(orderId);
        if (order == null)
            return new OperationResult { Success = false, Message = "Order not found" };

        if (order.Status != StatusO.CheckOut)
            return new OperationResult { Success = false, Message = "Order cannot be canceled" };

        order.Status = StatusO.Canceled;
        await _context.SaveChangesAsync();

        return new OperationResult { Success = true, Message = "Order canceled successfully" };
    }
}
