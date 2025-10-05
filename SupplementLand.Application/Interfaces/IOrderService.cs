using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OperationResult> AddOrder(OrderDto dto);
        Task<DataResult<OrderListDto>> GetOrders(OrderFilter filter);
        Task<OrderDetailDto> GetOrderDetail(int orderId);
        Task<OperationResult> CancelOrder(int orderId);
    }
}
