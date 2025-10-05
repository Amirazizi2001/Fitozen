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
    public interface IDiscountService
    {
        Task<OperationResult> AddDiscount(DiscountDto dto);
        Task<OperationResult> UpdateDiscount(UDiscountDto dto);
        Task<OperationResult> DeleteDiscount(int id);
        Task<Discount> GetDiscountById(int id);
        Task<DataResult<DiscountListDto>> GetDiscounts(DiscountFilter filter);
    }
}
