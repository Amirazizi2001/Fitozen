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
            var portfolio = await _portfolioService.GetPortfolioById(dto.PortfolioId);
            var totalPrice=await _portfolioService.PortfolioTotalSum(dto.PortfolioId);

            var order = new Order
            {
                PortfolioId = dto.PortfolioId,
                OrderDate = dto.OrderDate,
                Status = dto.Status,
                TotalPrice = totalPrice,
            };


            await _context.orders.AddAsync(order);
            portfolio.status =Status.Ordered;
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Order created successfully" };
        }
        catch (Exception ex)
        {
            return new OperationResult { Success = false, Message = $"Error creating order: {ex.Message}" };
        }
    }

    public async Task<DataResult<OrderListDto>> GetOrders(OrderFilter filter,int? userId)
    {
        IQueryable<Order> query = _context.orders
            .Include(o => o.Portfolio)
                .ThenInclude(p => p.User)
            .Include(o => o.Portfolio)
                .ThenInclude(p => p.PortfolioItems)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Status))
            query = query.Where(o => o.Status.ToString() == filter.Status);

        if (userId!=null)
            query = query.Where(o => o.Portfolio.UserId ==userId);

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
            OrderDate = order.OrderDate,
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

    public async Task<OrdersDetailDto> GetOrderProductDetail(int portfolioId)
    {
        var portfolio = await _context.portfolios.Include(p=>p.Order).Include(p=>p.User).FirstOrDefaultAsync(p => p.Id == portfolioId);
        
        
            var products = await _context.portfolioItems.Include(pi => pi.Product).ThenInclude(p => p.ProductVariants).Include(pi=>pi.Product)
            .ThenInclude(p=>p.Discount)
            .Where(pi => pi.PortfolioId == portfolioId).
                Select(pi => new OrderProductDto
                {
                    Id = pi.ProductId,
                    Name = pi.Product.Name,
                    Price = pi.Product.Price,
                    Quantity = pi.Quantity,
                    DisCount=pi.Product.Discount.Percentage,
                    Variant = pi.Product.ProductVariants.Where(pv => pv.Id == pi.VariantId).Select(pv => new ProductsVariantDto
                    {
                        ProductId = pv.ProductId,
                        Servings = pv.Serving,
                        Stock = pv.Stock,
                        Price = pv.Price,
                        Name = pv.VariantName,

                    }).FirstOrDefault(),
                    

                }).ToListAsync();



            var result = new OrdersDetailDto
            {
                Id = portfolio.Order.Id,
                FullName=portfolio.User.FullName,
                PortfolioName=portfolio.Name,
                OrderDate = portfolio.Order.OrderDate,
                Status = portfolio.Order.Status.ToString(),
                PortfolioId = portfolio.Id,
                UserId = portfolio.UserId,
                ProductsDetail = products,
                TotalAmount=portfolio.Order.TotalPrice,
                


            };

            return result;
        }

    public async Task<OrdersDto> GetOrder(int id)
    {
        var order=await _context.orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) { throw new Exception(); }
        return new OrdersDto
        {
            PortfolioId = order.PortfolioId,
            Status = order.Status,
            OrderDate = order.OrderDate,
        };
    }

    public async Task<OperationResult> ApplyOrderdiscount(string code, int orderId)
    {
       var discount=await _context.discounts.FirstOrDefaultAsync(d=>d.Code == code);
        if (discount == null) {return new OperationResult { Success = false,Message="discount doesn't exist"};}
        var order=await _context.orders.FirstOrDefaultAsync(o=>o.Id == orderId);
        if (order == null || order.Status.ToString() == "NotPaid") { return new OperationResult { Success = false, Message = "order doesn't exist" }; }
        var percentage = discount.Percentage;
        var oldTotalPrice = order.TotalPrice;
        var newPrice = oldTotalPrice - ((oldTotalPrice * percentage) / 100);
        if (discount.EndDate >= DateTime.UtcNow||discount.CountUsed==0) { return new OperationResult { Success = false, Message = "discount has been expired" }; }
        order.TotalPrice = newPrice;
        discount.CountUsed--;
        _context.SaveChanges();
        return new OperationResult { Success = true, Message = "Discount has been applied" };
    }
}

    

