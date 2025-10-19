using SupplementLand.Application.Dtos;
using SupplementLand.Application.Filters;
using SupplementLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Application.Interfaces
{
    public interface IPortfolioService
    {

        Task<OperationResult> AddItem(portfolioItemDto dto);
        Task<OperationResult> CreatePortfolio(PortfolioDto dto,int userId);
        Task<OperationResult> DeleteItem(int portfolioItemId);
        Task<OperationResult> DeletePortfolio(int portfolioId);
        Task<Portfolio> GetPortfolioById(int id);
        Task<PortfolioItem> GetPortfolioItem(int portfolioItemId);
        Task<DataResult<PIListDto>> GetPortfolioItems(PortfolioItemFilter filter);
        Task<decimal> PortfolioTotalSum(int portfolioId);
        Task<PortListDto> GetUserPortfolio(int userId);
        Task<OperationResult> UpdatePortfolioItem(UPortfolioItemDto dto);
    }
}
