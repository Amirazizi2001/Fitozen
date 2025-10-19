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
    public interface IRateService
    {
        Task<OperationResult> AddRate(RateDto dto,int userId);
        Task<OperationResult> UpdateRate(URateDto dto);
        Task<OperationResult> DeleteRate(int id);
        Task<DataResult<RateListDto>> GetProductRates(RateFilter filter);
        Task<Rate> GetRateById(int id);

    }
}
